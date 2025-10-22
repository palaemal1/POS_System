using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UpdateProductDTO
    {
        public string? productName { get; set; }
        public string? sku { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public decimal cost { get; set; }
        public int quantityInStock { get; set; }
        public string? categoryId { get; set; }
        public int reorderLevel { get; set; }
        public bool? activeFlag { get; set; }
        public string? updatedBy { get; set; }
        public DateTime updateDate { get; set; } = DateTime.UtcNow;
    }
}
