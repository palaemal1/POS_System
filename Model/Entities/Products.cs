using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Products:CommonCreated
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int? QuantityInStock {get;set;}
        public string? CategoryId { get; set; }
        public int? ReorderLevel { get; set; }
         
    }
}
