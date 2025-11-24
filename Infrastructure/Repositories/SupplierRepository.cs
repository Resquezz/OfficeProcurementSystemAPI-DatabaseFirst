using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using OfficeProcurementSystem.Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly OfficeProcurementDbContext _context;

        public SupplierRepository(OfficeProcurementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.Include(supplier => supplier.Category).ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(Guid id)
        {
            return await _context.Suppliers.Include(supplier => supplier.Category).FirstOrDefaultAsync(supplier => supplier.Id == id);
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
