using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Model.Common;
namespace Model.Entities
{
    public class Employees:CommonCreated
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Password { get; set; }
        public string? FullName { get; set; }
        public string? Role { get; set; }

    }
}
