using Model.DTO;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public  interface IOrderItemService
    {
        Task AddOrderItem(AddNewOrderItem input);
        Task<IEnumerable<OrderItems>> GetAllOrderItem();
        Task updateOrderItem(Guid id, UpdateOrderItemDTO input);
        Task DeleteOrderItem(Guid id);

        Task<IEnumerable<object>> GetAllOrderItemList();
        Task AddMultipleOrderItem(IEnumerable<AddNewOrderItem> inputs);
        Task<IEnumerable<OrderItems>> GetOrderItemWithPagination(int page, int pageSize);
        Task<IEnumerable<OrderItems>> GetOrderItemWithPaginationDesc<TKey>(int page, int pageSize, Expression<Func<OrderItems, TKey>> orderBy);
    }
}
