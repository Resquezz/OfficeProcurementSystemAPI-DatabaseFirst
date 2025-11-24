using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PurchaseViewModel
    {
        public PurchaseViewModel(Guid id, Guid userId, DateTime createdAt, Guid categoryId, string title, string description, Status status, decimal requestedAmount)
        {
            Id = id;
            UserId = userId;
            CreatedAt = createdAt;
            CategoryId = categoryId;
            Title = title;
            Description = description;
            Status = status;
            RequestedAmount = requestedAmount;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Status Status { get; set; }
        public decimal RequestedAmount { get; set; }
    }
}
