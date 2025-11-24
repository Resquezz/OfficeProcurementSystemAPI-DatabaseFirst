using Domain.Models;
using OfficeProcurementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAnomalyExpenseRepository
    {
        Task AddAsync(AnomalyExpense anomalyExpense);
        Task DeleteAsync(Guid id);
        Task<AnomalyExpense?> GetByIdAsync(Guid id);
        Task<ICollection<AnomalyExpense>> GetAllAsync();
        Task UpdateAsync(AnomalyExpense anomalyExpense);
    }
}
