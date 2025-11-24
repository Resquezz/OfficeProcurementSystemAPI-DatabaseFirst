using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class Budget
    {
        public Budget(decimal generalAmount, string name)
        {
            GeneralAmount = generalAmount;
            Name = name;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public decimal GeneralAmount { get; set; }

        public decimal AvailableAmount { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<ExpenseReport> ExpenseReports { get; set; } = new List<ExpenseReport>();
    }
}
