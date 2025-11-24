using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class User
    {
        public User(string name, string surname, int role, string email, string passwordHash)
        {
            Name = name;
            Surname = surname;
            Role = role;
            Email = email;
            PasswordHash = passwordHash;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public int Role { get; set; }

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public virtual ICollection<ExpenseReport> ExpenseReports { get; set; } = new List<ExpenseReport>();

        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
