using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using OfficeProcurementSystem.Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly OfficeProcurementDbContext _context;

        public UsersRepository(OfficeProcurementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _context.Users.Include(user => user.Purchases).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.Include(user => user.Purchases).FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
