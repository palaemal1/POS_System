using BAL.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.DTO;
using Model.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BAL.Service
{
    public class AuthService(DataContent content,IConfiguration configuration):IAuthService
    {
        //public async Task<Employees?> Register(AddNewEmployeeDTO input)
        //{
        //    if(await content.Employees.AnyAsync(e => e.EmployeeName == input.employeeName))
        //    {
        //        return null;
        //    }
        //    var emp = new Employees();
        //    var passwordHash = new PasswordHasher<Employees>().HashPassword(emp, input.password);

        //    emp.EmployeeName = input.employeeName;
        //    emp.Password = passwordHash;
        //     content.Employees.Add(emp);
        //    await content.SaveChangesAsync();
        //    return emp;
        //}


        public async Task<string?> Login(AddNewEmployeeDTO input)
        {
            var emp = await content.Employees.FirstOrDefaultAsync(e => e.EmployeeName == input.employeeName);
           
            if (emp is null)
            {
                return null;
            }
            if (new PasswordHasher<Employees>().VerifyHashedPassword(emp, emp.Password, input.password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            string token = CreateToken(emp);
            return token;
        }

        private string CreateToken(Employees emp)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,emp.EmployeeName), 
                new Claim(ClaimTypes.NameIdentifier,emp.EmployeeId.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration["AppSettings:Token"],
                audience: configuration["AppSettings:Token"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}
