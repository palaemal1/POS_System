using Model;
using Model.Entities;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class EmployeeRepository:GenericRepository<Employees>,IEmployeeRepository
    {
        public EmployeeRepository(DataContent context) : base(context) { }
    }
}
