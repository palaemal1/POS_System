using Model.DTO;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public interface IPaymentService
    {
        Task<Payments> GetPaymentById(Guid id);
        Task AddNewPayment(AddNewPayment input);
        Task UpdatePaymentMethod(Guid id, UpdatePaymentDTO input);
        
    }
}
