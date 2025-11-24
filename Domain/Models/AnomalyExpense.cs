using Domain.Models;

namespace OfficeProcurementSystem.Domain.Models;

public partial class AnomalyExpense
{
    public AnomalyExpense(Guid purchaseId, string description)
    {
        PurchaseId = purchaseId;
        Description = description;
    }

    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid PurchaseId { get; set; }

    public DateTime DetectedAt { get; set; }

    public string Description { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
