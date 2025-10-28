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
    public  class OrderItemRepository:GenericRepository<OrderItems>,IOrderItemRepository
    {
      private readonly DataContent _content;
      public  OrderItemRepository(DataContent context) : base(context) {
            _content = context;
        }

       public async Task<IEnumerable<object>> GetAllOrderItemList()
        {
            var orderItem = _content.OrderItems.Where(x => x.ActiveFlag == true);
            var order = _content.Orders.Where(x => x.ActiveFlag == true);
            var product = _content.Products.Where(x => x.ActiveFlag == true);
            var employee = _content.Employees.Where(x => x.ActiveFlag == true);
            var category = _content.Categories.Where(x => x.ActiveFlag == true);

            var orderItemList = (from oIL in orderItem
                                 join p in product on oIL.ProductId equals p.ProductId.ToString()
                                 join c in category on p.CategoryId equals c.CategoryId.ToString()
                                 join o in order on oIL.OrderId equals o.OrderId.ToString()
                                 join e in employee on o.EmployeeId equals e.EmployeeId.ToString()
                                 select new
                                 {
                                     qty = oIL.Qty,
                                     lineTotal = oIL.LineTotal,
                                     productName = p.ProductName,
                                     paymentStatus = o.PaymentStatus,
                                     employeeName=e.EmployeeName, 
                                     orderStatus=o.OrderStatus, 
                                     discount=oIL.Discount, 
                                     unitProce=oIL.UnitPrice, 
                                     orderNumber=o.OrderNumber, 
                                     taxAmt=o.TaxAmount, 
                                     categoryName=c.CategoryName
                                 }).ToList();

            return orderItemList;
        }
    }
}
