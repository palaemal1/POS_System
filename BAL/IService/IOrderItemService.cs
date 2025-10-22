using Model.DTO;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
