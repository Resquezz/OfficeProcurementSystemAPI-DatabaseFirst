using Application.ViewModels;
using OfficeProcurementSystem.Domain.Models;

namespace Application.Mappers
{
    public static class AnomalyExpenseMapper
    {
        public static AnomalyExpenseViewModel ToResponse(this AnomalyExpense anomalyExpense)
        {
            return new AnomalyExpenseViewModel(anomalyExpense.Id, anomalyExpense.PurchaseId, anomalyExpense.DetectedAt,
                anomalyExpense.Description);
        }
    }
}
