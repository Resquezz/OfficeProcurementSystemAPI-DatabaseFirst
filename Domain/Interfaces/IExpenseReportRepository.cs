using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IExpenseReportRepository
    {
        Task AddAsync(ExpenseReport expenseReport);
        Task DeleteAsync(Guid id);
        Task<ExpenseReport?> GetByIdAsync(Guid id);
        Task<ICollection<ExpenseReport>> GetAllAsync();
        Task UpdateAsync(ExpenseReport user);
    }
}
