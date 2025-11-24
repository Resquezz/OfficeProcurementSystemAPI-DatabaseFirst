using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public Role Role { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
