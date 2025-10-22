using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Model.Common;
namespace Model.Entities
{
    public class Orders:CommonCreated
    {
        [Key]
        public Guid OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public string? CustomerId { get; set; }
        public string? EmployeeId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string? PaymentStatus { get; set; }
        public string? OrderStatus { get; set; }


    }
}
