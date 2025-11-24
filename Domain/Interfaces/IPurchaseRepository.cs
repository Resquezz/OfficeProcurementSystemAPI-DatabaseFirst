using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurchaseRepository
    {
        Task AddAsync(Purchase purchase);
        Task DeleteAsync(Guid id);
        Task<Purchase?> GetByIdAsync(Guid id);
        Task<ICollection<Purchase>> GetAllAsync();
        Task UpdateAsync(Purchase user);
    }
}
