using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Common;

namespace Repository.IUnitOfWork
{
    public interface IUnitofWork:IDisposable
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IOrderItemRepository OrderItem { get; }
        IInventoryTransactionRepository InventoryTransaction { get; }
        IEmployeeRepository Employee { get; }
        IOrderRepository Order { get; }
        ICustomerRepository Customer { get; }
        AppSettings AppSettings { get; }
        Task<int> SaveChangesAsync();
    }
}
