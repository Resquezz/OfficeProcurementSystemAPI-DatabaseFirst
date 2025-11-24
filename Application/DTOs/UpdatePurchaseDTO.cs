using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdatePurchaseDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? UserId { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public Status? Status { get; set; } = Domain.Enums.Status.Pending;
        public decimal? RequestedAmount { get; set; }
    }
}
