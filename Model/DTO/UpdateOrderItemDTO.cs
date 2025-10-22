using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UpdateOrderItemDTO
    {
        public string? orderId { get; set; }
        public string? productId { get; set; }
        public int qty { get; set; }
        public decimal unitprice { get; set; }
        public decimal discount { get; set; }
        public decimal? lineTotal { get; set; }
        public bool? activeFlag { get; set; }
        public string? updatedBy { get; set; }
        public DateTime updatedTime { get; set; } = DateTime.UtcNow;
    }
}
