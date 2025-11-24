using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateAnomalyExpenseDTO
    {
        public Guid Id { get; set; }
        public Guid? PurchaseId { get; set; }
        public string? Description { get; set; } = null!;
    }
}
