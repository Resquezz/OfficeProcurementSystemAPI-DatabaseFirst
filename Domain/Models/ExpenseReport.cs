using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class ExpenseReport
    {
        public ExpenseReport(string name, Guid budgetId, Guid userId, decimal totalExpenses)
        {
            Name = name;
            BudgetId = budgetId;
            UserId = userId;
            TotalExpenses = totalExpenses;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public Guid BudgetId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid UserId { get; set; }

        public decimal TotalExpenses { get; set; }

        public virtual Budget Budget { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
