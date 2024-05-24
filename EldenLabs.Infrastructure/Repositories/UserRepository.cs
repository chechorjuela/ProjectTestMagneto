using EldenLabs.Domain.Entities;
using EldenLabs.Domain.Repositories;
using EldenLabs.Infrastructure.AppContext;
using EldenLabs.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> ExistUserByUsername(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username );
        }

        public async Task<User> SignInUser(User user)
        {
            return await _context.Users.Where( u => u.UserName == user.UserName).FirstOrDefaultAsync();
        }
    }
}
