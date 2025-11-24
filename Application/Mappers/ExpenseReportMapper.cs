using Application.ViewModels;
using Domain.Models;

namespace Application.Mappers
{
    public static class ExpenseReportMapper
    {
        public static ExpenseReportViewModel ToResponse(this ExpenseReport report)
        {
            return new ExpenseReportViewModel(report.Id, report.Name, report.BudgetId, report.CreatedAt, report.UserId, report.TotalExpenses);
        }
    }
}
