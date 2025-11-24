using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(Guid id, string name, Role role, string surname, string email)
        {
            Id = id;
            Name = name;
            Role = role;
            Surname = surname;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Role Role { get; set; }
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
