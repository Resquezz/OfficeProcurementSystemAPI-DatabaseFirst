using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class AnomalyExpenseViewModel
    {
        public AnomalyExpenseViewModel(Guid id, Guid purchaseId, DateTime detectedAt, string description)
        {
            Id = id;
            PurchaseId = purchaseId;
            DetectedAt = detectedAt;
            Description = description;
        }

        public Guid Id { get; set; }
        public Guid PurchaseId { get; set; }
        public DateTime DetectedAt { get; set; }
        public string Description { get; set; } = null!;
    }
}
