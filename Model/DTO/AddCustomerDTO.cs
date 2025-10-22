using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public  class AddCustomerDTO
    {
        public Guid CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public decimal? LoyaltyPoints { get; set; }
        public bool? activeFlag { get; set; }
        public string? createdBy { get; set; }
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
    }
}
