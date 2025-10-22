using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UpdateCustomer
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public decimal? loyaltyPoints { get; set; }
        public string? updatedBy { get; set; }
        public bool? activeFlag { get; set; }
        public DateTime updatedDate { get; set; } = DateTime.UtcNow;
    }
}
