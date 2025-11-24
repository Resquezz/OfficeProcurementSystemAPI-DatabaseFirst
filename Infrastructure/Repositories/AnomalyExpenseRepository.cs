using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeProcurementSystem.Domain.Models;
using OfficeProcurementSystem.Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AnomalyExpenseRepository : IAnomalyExpenseRepository
    {
        private readonly OfficeProcurementDbContext _context;

        public AnomalyExpenseRepository(OfficeProcurementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AnomalyExpense anomalyExpense)
        {
            await _context.AnomalyExpenses.AddAsync(anomalyExpense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var anomalyExpenses = await _context.AnomalyExpenses.FindAsync(id);
            if (anomalyExpenses != null)
            {
                _context.AnomalyExpenses.Remove(anomalyExpenses);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<AnomalyExpense>> GetAllAsync()
        {
            return await _context.AnomalyExpenses.Include(expense => expense.Purchase).ToListAsync();
        }

        public async Task<AnomalyExpense?> GetByIdAsync(Guid id)
        {
            return await _context.AnomalyExpenses.Include(expense => expense.Purchase)
                .FirstOrDefaultAsync(expense => expense.Id == id);
        }

        public async Task UpdateAsync(AnomalyExpense anomalyExpense)
        {
            _context.AnomalyExpenses.Update(anomalyExpense);
            await _context.SaveChangesAsync();
        }
    }
}
