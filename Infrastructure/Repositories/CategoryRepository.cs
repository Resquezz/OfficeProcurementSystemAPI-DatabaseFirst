using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using OfficeProcurementSystem.Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OfficeProcurementDbContext _context;

        public CategoryRepository(OfficeProcurementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(category => category.Purchases)
                .Include(category => category.Suppliers).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.Include(category => category.Purchases).Include(category => category.Suppliers)
                .FirstOrDefaultAsync(category => category.Id == id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
