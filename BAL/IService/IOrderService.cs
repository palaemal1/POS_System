using Model.DTO;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public interface IOrderService
    {
        Task<IEnumerable<Orders>> GetAllOrder();
        Task AddOrder(AddNewOrder input);
        Task UpdateOrder(Guid id, UpdateOrderDTO input);
        Task DeleteOrder(Guid id);
    }
}
