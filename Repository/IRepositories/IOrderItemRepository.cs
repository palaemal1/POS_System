
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IOrderItemRepository:IGenericRepository<OrderItems>
    {
        Task<IEnumerable<object>> GetAllOrderItemList();
        Task<IEnumerable<object>> GetAllOrderItemListWithPagination(int page, int pageSize);
    }
}
