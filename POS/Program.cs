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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.Extensions.Options;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var appSettings = new AppSettings();

        builder.Configuration.GetSection("AppSettings").Bind(appSettings);


        builder.Services.AddControllers();


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition(BearerTokenDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter bearer authorization: `Bearer Generated-JWT-Token`",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = BearerTokenDefaults.AuthenticationScheme
                }
            },
            new string[] {}
        }
            });
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "POS API",
                Version = "v1",
                Description = "Backend API for Power Apps and Power Automate integration"
            });
            c.CustomOperationIds(apiDesc =>
            {

                return apiDesc.TryGetMethodInfo(out var methodInfo) ? methodInfo.Name : null;
            });


            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
                c.IncludeXmlComments(xmlPath);
        });
        ServiceManager.SetServiceInfo(builder.Services, appSettings);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer=true,
                     ValidIssuer = builder.Configuration["AppSettings:Issuer"], 
                     ValidateAudience=true,
                     ValidAudience = builder.Configuration["AppSettings:Audience"], 
                     ValidateLifetime=true, 
                     IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)), 
                     ValidateIssuerSigningKey=true
                 };
                 });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowPowerApps",
                policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });


       

        var app = builder.Build();

        //using (var scope = app.Services.CreateScope())
        //{
        //    var db = scope.ServiceProvider.GetRequiredService<DataContent>();
        //    try
        //    {
        //        var canConnect = db.Database.CanConnect();
        //        Console.WriteLine(canConnect
        //            ? " Database connected successfully"
        //            : " Database connection failed");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($" Error connecting to database: {ex.Message}");
        //    }
        //}


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "POS API v1");
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.UseCors("AllowPowerApps");

        app.MapControllers();

        app.Run();
    }
}