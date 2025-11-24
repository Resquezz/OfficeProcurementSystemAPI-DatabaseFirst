using Domain.Enums;
using OfficeProcurementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class Purchase
    {
        public Purchase(Guid userId, Guid categoryId, string title, string description, decimal requestedAmount)
        {
            UserId = userId;
            CategoryId = categoryId;
            Title = title;
            Description = description;
            RequestedAmount = requestedAmount;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CategoryId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Status { get; set; } = null!;

        public decimal RequestedAmount { get; set; }

        public virtual ICollection<AnomalyExpense> AnomalyExpenses { get; set; } = new List<AnomalyExpense>();

        public virtual Category Category { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
