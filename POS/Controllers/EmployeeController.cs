﻿using BAL.IService;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using Repository.IUnitOfWork;

namespace POS.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController:ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IUnitofWork unitofWork,IEmployeeService employeeService)
        {
            _unitofWork = unitofWork;
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var data = await _employeeService.GetAllEmployee();
            return Ok(new ResponseModel { Data = data });
        }

        [HttpPost("AddNewEmployee")]
        public async Task<IActionResult> AddNewEmployee(AddNewEmployee input)
        {
            await _employeeService.AddNewEmployee(input);
            return Ok("Add employee successfully");
        }

        [HttpPost("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Guid id,UpdateEmployeeDTO input)
        {
            await _employeeService.UpdateEmployee(id, input);
            return Ok("Update successfully");
        }

        [HttpGet("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok("Delete successfully");
        }
    }
}
