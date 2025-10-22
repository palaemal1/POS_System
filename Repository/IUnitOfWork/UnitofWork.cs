using Microsoft.Extensions.Options;
using Model;
using Model.Common;
using Repository.IRepositories;
using Repository.IUnitOfWork;
using Repository.Repositories;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DataContent _content;

        public UnitofWork(DataContent content, IOptions<AppSettings> appsettings)
        {
            _content = content ?? throw new ArgumentNullException(nameof(content));
            AppSettings = appsettings?.Value ?? throw new ArgumentNullException(nameof(appsettings));

            Product = new ProductRepository(_content);
            Category = new CategoryRepository(_content);
            OrderItem = new OrderItemRepository(_content);
            InventoryTransaction = new InventoryTransactionRepository(_content);
            Employee = new EmployeeRepository(_content);
            Order = new OrderRepository(_content);
            Customer = new CustomerRepository(_content);
        }

        

        public void Dispose()
        {
            _content?.Dispose();
        }
        public IProductRepository Product { get; set; }
        public ICategoryRepository Category { get; set; }
        public IOrderItemRepository OrderItem { get; set; }
        public IInventoryTransactionRepository InventoryTransaction { get; set; }
        public IEmployeeRepository Employee { get; set; }
        public IOrderRepository Order { get; set; }
        public ICustomerRepository Customer { get; set; }

        public AppSettings AppSettings { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _content.SaveChangesAsync();
        }
    }
}
