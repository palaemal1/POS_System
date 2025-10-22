using BAL.IService;
using BAL.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.Common;
using Repository;
using Repository.IUnitOfWork;


namespace BAL.ServiceManager
{
    public class ServiceManager
    {
        public static void SetServiceInfo(IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContextPool<DataContent>(optionsAction =>
            {
                 optionsAction.UseSqlServer(appSettings.ConnectionStrings);
            });
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            //services.AddScoped<IInventoryTransactionService, InventoryTransactionService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }

}
