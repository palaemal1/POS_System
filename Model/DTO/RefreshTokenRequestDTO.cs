using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class RefreshTokenRequestDTO
    {
        public Guid employeeId { get; set; }
        public required string refreshToken { get; set; }
    }
}
