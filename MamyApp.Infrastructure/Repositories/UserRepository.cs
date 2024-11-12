using MamyApp.Core.Entities;
using MamyApp.Core.Interfaces;
using MamyApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MamyApp.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

    
    }
}
