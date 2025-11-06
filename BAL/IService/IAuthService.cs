using Model.DTO;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public interface IAuthService
    {
       // Task<Employees?> Register(AddNewEmployeeDTO input);
        Task<string?> Login(AddNewEmployeeDTO input);
    }
}
