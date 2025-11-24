using Application.DTOs;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAnomalyExpenseService
    {
        Task<AnomalyExpenseViewModel> CreateAnomalyExpenseAsync(CreateAnomalyExpenseDTO dto);
        Task<AnomalyExpenseViewModel> UpdateAnomalyExpenseAsync(UpdateAnomalyExpenseDTO dto);
        Task DeleteAnomalyExpenseAsync(DeleteAnomalyExpenseDTO dto);
        Task<ICollection<AnomalyExpenseViewModel>?> GetAllAnomalyExpensesAsync();
        Task<AnomalyExpenseViewModel> GetAnomalyExpenseByIdAsync(Guid id);
    }
}
