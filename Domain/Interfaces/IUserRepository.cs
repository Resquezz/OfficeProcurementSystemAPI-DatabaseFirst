using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task DeleteAsync(Guid id);
        Task<User?> GetByIdAsync(Guid id);
        Task<ICollection<User>> GetAllAsync();
        Task UpdateAsync(User user);
    }
}
