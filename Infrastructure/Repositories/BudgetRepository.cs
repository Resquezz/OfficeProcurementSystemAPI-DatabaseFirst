using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using OfficeProcurementSystem.Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly OfficeProcurementDbContext _context;

        public BudgetRepository(OfficeProcurementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Budget budget)
        {
            await _context.Budgets.AddAsync(budget);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var budget = await _context.Budgets.FindAsync(id);
            if (budget != null)
            {
                _context.Budgets.Remove(budget);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Budget>> GetAllAsync()
        {
            return await _context.Budgets.Include(budget => budget.ExpenseReports).ToListAsync();
        }

        public async Task<Budget?> GetByIdAsync(Guid id)
        {
            return await _context.Budgets.Include(budget => budget.ExpenseReports).FirstOrDefaultAsync(budget => budget.Id == id);
        }

        public async Task UpdateAsync(Budget budget)
        {
            _context.Budgets.Update(budget);
            await _context.SaveChangesAsync();
        }
    }
}
