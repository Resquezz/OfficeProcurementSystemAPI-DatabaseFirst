using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task DeleteAsync(Guid id);
        Task<Category?> GetByIdAsync(Guid id);
        Task<ICollection<Category>> GetAllAsync();
        Task UpdateAsync(Category category);
    }
}
