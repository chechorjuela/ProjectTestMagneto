using EldenLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User> SignInUser(User user);
        public Task<bool> ExistUserByUsername(string username);
    }
}
