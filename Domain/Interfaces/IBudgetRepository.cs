using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBudgetRepository
    {
        Task AddAsync(Budget budget);
        Task DeleteAsync(Guid id);
        Task<Budget?> GetByIdAsync(Guid id);
        Task<ICollection<Budget>> GetAllAsync();
        Task UpdateAsync(Budget budget);
    }
}
