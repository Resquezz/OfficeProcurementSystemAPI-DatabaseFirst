using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateBudgetDTO
    {
        public Guid Id { get; set; }
        public decimal? GeneralAmount { get; set; }
        public decimal? AvailableAmount { get; set; }
        public string? Name { get; set; } = null!;
    }
}
