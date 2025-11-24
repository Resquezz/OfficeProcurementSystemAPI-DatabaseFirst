using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ExpenseReportViewModel
    {
        public ExpenseReportViewModel(Guid id, string name, Guid budgetId, DateTime createdAt, Guid userId, decimal totalExpenses)
        {
            Id = id;
            Name = name;
            BudgetId = budgetId;
            CreatedAt = createdAt;
            UserId = userId;
            TotalExpenses = totalExpenses;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid BudgetId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalExpenses { get; set; }
    }
}
