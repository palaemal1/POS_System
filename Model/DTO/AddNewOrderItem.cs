using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AddNewOrderItem
    {
        public Guid OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int qty { get; set; }
        public decimal unitPrice { get; set; }
        public decimal discount { get; set; }
        public decimal? lineTotal { get; set; }
        public bool? activeFlag { get; set; }
        public string? createdBy { get; set; }
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
    }
}
