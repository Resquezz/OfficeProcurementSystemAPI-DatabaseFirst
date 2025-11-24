using Application.ViewModels;
using Domain.Models;

namespace Application.Mappers
{
    public static class BudgetMapper
    {
        public static BudgetViewModel ToResponse(this Budget budget)
        {
            return new BudgetViewModel(budget.Id, budget.GeneralAmount, budget.AvailableAmount, budget.Name);
        }
    }
}
