using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task AddAsync(Supplier supplier);
        Task DeleteAsync(Guid id);
        Task<Supplier?> GetByIdAsync(Guid id);
        Task<ICollection<Supplier>> GetAllAsync();
        Task UpdateAsync(Supplier supplier);
    }
}
