using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class CategoryDTO
    {
        public Guid categoryId { get; set; }
        public string? categoryName { get; set; }
        public string? description { get; set; }
        public string? categoryCode { get; set; }
        public bool? activeFlag { get; set; }
        public string? createdBy { get; set; }
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
    }
}
