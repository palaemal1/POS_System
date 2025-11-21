using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AddNewPayment
    {
        public Guid paymentId { get; set; }
        public string? orderId { get; set; }
        public string? paymentMethod { get; set; }
        public decimal amount { get; set; }
        public DateTime paymentDate { get; set; }
        public bool? activeFlag { get; set; }
        public string? createdBy { get; set; }
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
    }
}
