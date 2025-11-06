using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AddNewEmployeeDTO
    {
       // public Guid employeeId { get; set; }
        public string employeeName { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
