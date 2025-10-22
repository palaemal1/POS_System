using Model;
using Model.Entities;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class OrderItemRepository:GenericRepository<OrderItems>,IOrderItemRepository
    {
      public  OrderItemRepository(DataContent context) : base(context) { }
    }
}
