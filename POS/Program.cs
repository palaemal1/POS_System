using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Model.Common;
using BAL.ServiceManager;
using Microsoft.EntityFrameworkCore;  // Required for Database.CanConnect()
using Repository;                    // Namespace where DataContext is
using Microsoft.Extensions.DependencyInjection;
using Model;
using Swashbuckle.AspNetCore.SwaggerGen;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var appSettings = new AppSettings();

        // Load AppSettings from appsettings.json
        builder.Configuration.GetSection("AppSettings").Bind(appSettings);

        // Add essential services
        builder.Services.AddControllers();

        // Enable Swagger/OpenAPI
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "POS API",
                Version = "v1",
                Description = "Backend API for Power Apps and Power Automate integration"
            });
            c.CustomOperationIds(apiDesc =>
            {
                // Use the method name as operationId
                return apiDesc.TryGetMethodInfo(out var methodInfo) ? methodInfo.Name : null;
            });

            // Optional: Include XML comments if generated
            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
                c.IncludeXmlComments(xmlPath);
        });

        // Enable CORS for Power Apps / Power Automate
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowPowerApps",
                policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        // Register all your services and DB using ServiceManager helper
        ServiceManager.SetServiceInfo(builder.Services, appSettings);

        var app = builder.Build();

        // Test database connection before app starts
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DataContent>();
            try
            {
                var canConnect = db.Database.CanConnect();
                Console.WriteLine(canConnect
                    ? " Database connected successfully"
                    : " Database connection failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error connecting to database: {ex.Message}");
            }
        }

        // Configure HTTP pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "POS API v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowPowerApps");

        app.MapControllers();

        app.Run();
    }
}
