using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using OfficeProcurementSystem.Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly OfficeProcurementDbContext _context;

        public PurchaseRepository(OfficeProcurementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Purchase purchase)
        {
            await _context.Purchases.AddAsync(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Purchase>> GetAllAsync()
        {
            return await _context.Purchases.Include(purchase => purchase.User)
                .Include(purchase => purchase.AnomalyExpenses).ToListAsync();
        }

        public async Task<Purchase?> GetByIdAsync(Guid id)
        {
            return await _context.Purchases.Include(purchase => purchase.User)
                .Include(purchase => purchase.AnomalyExpenses).FirstOrDefaultAsync(purchase => purchase.Id == id);
        }

        public async Task UpdateAsync(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
            await _context.SaveChangesAsync();
        }
    }
}
