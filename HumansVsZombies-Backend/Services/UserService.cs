using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly HvZDbContext _context;

        public UserService(HvZDbContext context)
        {
            _context = context;
        }

        public Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
