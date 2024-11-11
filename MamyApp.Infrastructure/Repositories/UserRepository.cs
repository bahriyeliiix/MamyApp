using MamyApp.Core.Entities;
using MamyApp.Core.Interfaces;
using MamyApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MamyApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            // Diğer alanları da güncelleyebilirsiniz

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
