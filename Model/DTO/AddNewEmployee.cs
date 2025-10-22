using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AddNewEmployee
    {
        public Guid EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? password { get; set; }
        public string? fullName { get; set; }
        public string? role { get; set; }
        public bool? activeFlag { get; set; }
        public string? createdBy { get; set; }
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
        
    }
}
