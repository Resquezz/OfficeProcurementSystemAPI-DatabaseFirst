using Application.DTOs;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IBudgetService
    {
        Task<BudgetViewModel> CreateBudgetAsync(CreateBudgetDTO dto);
        Task<BudgetViewModel> UpdateBudgetAsync(UpdateBudgetDTO dto);
        Task DeleteBudgetAsync(DeleteBudgetDTO dto);
        Task<ICollection<BudgetViewModel>?> GetAllBudgetsAsync();
        Task<BudgetViewModel> GetBudgetByIdAsync(Guid id);
    }
}
