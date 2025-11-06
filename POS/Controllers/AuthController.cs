using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Entities;
using BAL.IService;
namespace POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
      
        //[HttpPost("register")]
        //public async Task<ActionResult<Employees>> Register(AddNewEmployeeDTO input)
        //{
        //    var emp = await authService.Register(input);
        //    if(emp is null)
        //    {
        //        return BadRequest("Employee already exists.");
        //    }
        //    return Ok(emp);
        //}

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AddNewEmployeeDTO input)
        {
            var token = await authService.Login(input);
            if(token is null)
            {
                return BadRequest("Invalid employee name or password!");
            }
            return Ok(token);
        }

        

    }
}
