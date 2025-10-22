﻿using BAL.IService;
using Model;
using Model.DTO;
using Model.Entities;
using Repository.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    internal class EmployeeService:IEmployeeService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly DataContent _content;
        public EmployeeService(IUnitofWork unitofWork,DataContent content)
        {
            _unitofWork = unitofWork;
            _content = content;
        }

        public async Task<IEnumerable<Employees>> GetAllEmployee()
        {
            var data = await _unitofWork.Employee.GetAll();
            return  data ;
        }
        public async Task AddNewEmployee(AddNewEmployee input)
        {
            var data =new Employees()
            {
                EmployeeName = input.EmployeeName,
                Password=input.password,
                FullName=input.fullName, 
                Role=input.role,
                ActiveFlag=input.activeFlag, 
                CreatedAt=input.createdDate, 
                CreatedBy=input.createdBy
            };
            await _unitofWork.Employee.Add(data);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Guid id, UpdateEmployeeDTO input)
        {
            var data = (await _unitofWork.Employee.GetByCondition(x => x.EmployeeId == id)).FirstOrDefault();
            if(data!= null)
            {
                data.EmployeeName = input.employeeName;
                data.Password = input.password;
                data.FullName = input.fullName;
                data.Role = input.role;
                data.ActiveFlag = input.activeFlag;
                data.UpdatedAt = input.updatedDate;
                data.UpdatedBy = input.updatedBy;
            }
             _unitofWork.Employee.Update(data);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task DeleteEmployee(Guid id)
        {
            var data = (await _unitofWork.Employee.GetByCondition(x => x.EmployeeId == id)).FirstOrDefault();
            if (data != null)
            {
                data.ActiveFlag = false;
            }
            _unitofWork.Employee.Update(data);
            await _unitofWork.SaveChangesAsync();
        }
    }
}
