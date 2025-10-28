using BAL.IService;
using Model;
using Model.DTO;
using Model.Entities;
using Repository.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    internal class OrderItemService:IOrderItemService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly DataContent _content;
        public OrderItemService(IUnitofWork unitofWork,DataContent content)
        {
            _unitofWork = unitofWork;
            _content = content;
        }


        public async Task<IEnumerable<OrderItems>> GetAllOrderItem()
        {
            var data = await _unitofWork.OrderItem.GetAll();
            return data;
        }

        public async Task<IEnumerable<OrderItems>> GetOrderItemWithPagination(int page,int pageSize)
        {
            var data = await _unitofWork.OrderItem.GetAllAsyncWithPagination(page, pageSize);
            return data;
        }


        public async Task<IEnumerable<OrderItems>> GetOrderItemWithPaginationDesc<TKey>(int page,int pageSize,Expression<Func<OrderItems,TKey>> orderBy)
        {
            var data = await _unitofWork.OrderItem.GetAllAsyncWithPaginationByDesc(page, pageSize, orderBy);
            return data;
        } 

        public async Task AddOrderItem(AddNewOrderItem input)
        {
            var data = new OrderItems()
            {
                OrderId = input.OrderId,
                ProductId = input.ProductId,
                Qty = input.qty,
                UnitPrice = input.unitPrice,
                Discount = input.discount,
                LineTotal= (input.unitPrice - input.discount)* input.qty,
                ActiveFlag = input.activeFlag,
                CreatedAt = input.createdDate,
                CreatedBy = input.createdBy

            };
            await _unitofWork.OrderItem.Add(data);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task AddMultipleOrderItem(IEnumerable<AddNewOrderItem> inputs)
        {
            if (inputs == null || !inputs.Any())
                throw new ArgumentNullException(nameof(inputs));
            var data =inputs.Select(input=> new OrderItems()
            {
                OrderId = input.OrderId,
                ProductId = input.ProductId,
                Qty = input.qty,
                UnitPrice = input.unitPrice,
                Discount = input.discount,
                LineTotal = (input.unitPrice - input.discount) * input.qty,
                ActiveFlag = input.activeFlag,
                CreatedAt = input.createdDate,
                CreatedBy = input.createdBy
            });
            await _unitofWork.OrderItem.AddMultiple(data);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task updateOrderItem(Guid id,UpdateOrderItemDTO input)
        {
            var data = (await _unitofWork.OrderItem.GetByCondition(x => x.OrderItemId == id)).FirstOrDefault();
            if(data != null)
            {
                data.OrderId = input.orderId;
                data.ProductId = input.productId;
                data.Qty = input.qty;
                data.UnitPrice = input.unitprice;
                data.Discount = input.discount;
                data.LineTotal = (input.unitprice - input.discount) * input.qty;
                data.ActiveFlag = input.activeFlag;
                data.UpdatedBy = input.updatedBy;
                data.UpdatedAt = input.updatedTime;
            }
             _unitofWork.OrderItem.Update(data);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task DeleteOrderItem(Guid id)
        {
            var data = (await _unitofWork.OrderItem.GetByCondition(x => x.OrderItemId == id)).FirstOrDefault();
            if (data != null)
            {
                data.ActiveFlag = false;
            }

             _unitofWork.OrderItem.Update(data);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<object>> GetAllOrderItemList()
        {
            var data = await _unitofWork.OrderItem.GetAllOrderItemList();
            return data;
        }
    }
}
