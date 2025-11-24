using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using OfficeProcurementSystem.Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ExpenseReportRepository : IExpenseReportRepository
    {
        private readonly OfficeProcurementDbContext _context;

        public ExpenseReportRepository(OfficeProcurementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ExpenseReport report)
        {
            await _context.ExpenseReports.AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var report = await _context.ExpenseReports.FindAsync(id);
            if (report != null)
            {
                _context.ExpenseReports.Remove(report);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<ExpenseReport>> GetAllAsync()
        {
            return await _context.ExpenseReports.Include(report => report.User).Include(report => report.Budget).ToListAsync();
        }

        public async Task<ExpenseReport?> GetByIdAsync(Guid id)
        {
            return await _context.ExpenseReports.Include(report => report.User).Include(report => report.Budget)
                .FirstOrDefaultAsync(purchase => purchase.Id == id);
        }

        public async Task UpdateAsync(ExpenseReport report)
        {
            _context.ExpenseReports.Update(report);
            await _context.SaveChangesAsync();
        }
    }
}
