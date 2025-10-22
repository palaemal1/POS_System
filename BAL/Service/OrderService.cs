using BAL.IService;
using Model;
using Model.DTO;
using Model.Entities;
using Repository.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    internal class OrderService:IOrderService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly DataContent _content;
        public OrderService(IUnitofWork unitofWork,DataContent content)
        {
            _unitofWork = unitofWork;
            _content = content;
        }

        public async Task<IEnumerable<Orders>> GetAllOrder()
        {
            var data = await _unitofWork.Order.GetAll();
            return data;
        }
        public async Task AddOrder(AddNewOrder input)
        {
            var data = new Orders()
            {
                OrderNumber = input.orderNumber,
                CustomerId = input.customerId,
                EmployeeId = input.employeeId,
                TotalAmount = input.totalAmt ,
                DiscountAmount = input.discountAmt,
                TaxAmount = input.taxAmt,
                NetAmount = input.totalAmt -input.discountAmt + input.taxAmt,
                PaymentStatus = input.paymentStatus,
                OrderStatus=input.orderStatus,
                ActiveFlag = input.activeFlag,
                CreatedAt = input.createdDate,
                CreatedBy = input.createdBy
            };
            await _unitofWork.Order.Add(data);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task UpdateOrder(Guid id,UpdateOrderDTO input)
        {
            var data = (await _unitofWork.Order.GetByCondition(x => x.OrderId == id)).FirstOrDefault();
            if (data != null)
            {
                data.OrderNumber = input.orderNumber;
                data.CustomerId = input.customerId;
                data.EmployeeId = input.employeeId;
                data.TotalAmount = input.totalAmt;
                data.DiscountAmount = input.discountAmt;
                data.TaxAmount = input.taxAmt;
                data.PaymentStatus = input.paymentStatus;
                data.OrderStatus = input.orderStatus;
                data.NetAmount = input.totalAmt - input.discountAmt + input.taxAmt;
                data.ActiveFlag = input.activeFlag;
                data.UpdatedBy = input.updatedBy;
                data.UpdatedAt = input.updatedDate;
                
            }
             _unitofWork.Order.Update(data);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task DeleteOrder(Guid id)
        {
            var data = (await _unitofWork.Order.GetByCondition(x => x.OrderId == id)).FirstOrDefault();
            if (data != null)
            {
                data.ActiveFlag = false;
            }
             _unitofWork.Order.Update(data);
            await _unitofWork.SaveChangesAsync();
        }
    }
}
