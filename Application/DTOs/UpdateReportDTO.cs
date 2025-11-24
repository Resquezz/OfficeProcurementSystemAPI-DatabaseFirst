using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateReportDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = null!;
        public Guid? BudgetId { get; set; }
        public Guid? UserId { get; set; }
        public decimal? TotalExpenses { get; set; }
    }
}
