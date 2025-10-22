using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Model.Common;
namespace Model.Entities
{
    public class Customers:CommonCreated
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public decimal? LoyaltyPoints { get; set; }

    }
}
