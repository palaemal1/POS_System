using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Model.Common;
namespace Model.Entities
{
    public class OrderItems:CommonCreated
    {
        [Key]
        public Guid OrderItemId { get; set; }
        public string? OrderId { get; set; }
        public string? ProductId { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal LineTotal { get; set; }

    }
}
