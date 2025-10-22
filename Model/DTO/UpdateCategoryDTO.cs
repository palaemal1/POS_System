using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UpdateCategoryDTO
    {
        
        public string categoryName { get; set; }
        public string? description { get; set; }
        public string? categoryCode { get; set; }
        public bool? activeFlag { get; set; }
        public string? updatedBy { get; set; }
        public DateTime updatedDate { get; set; } = DateTime.UtcNow;
    }
}
