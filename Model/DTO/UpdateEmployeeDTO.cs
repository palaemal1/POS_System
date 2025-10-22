using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UpdateEmployeeDTO
    {
        public string? employeeName { get; set; }
        public string? password { get; set; }
        public string? fullName { get; set; }
        public string? role { get; set; }
        public bool? activeFlag { get; set; }
        public string? updatedBy { get; set; }
        public DateTime updatedDate { get; set; } = DateTime.UtcNow;
    }
}
