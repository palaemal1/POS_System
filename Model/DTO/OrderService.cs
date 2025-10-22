using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class OrderService
    {
        public Guid OrderId { get; set; }
        public string? orderNumber { get; set; }
        public string? customerId { get; set; }
        public string? employeeId { get; set; }
        public decimal totalAmt { get; set; }
        public decimal discountAmt { get; set; }
        public decimal taxAmt { get; set; }
        public decimal netAmt { get; set; }
        public string? paymentStatus { get; set; }
        public bool? activeFlag { get; set; }

    }
}
