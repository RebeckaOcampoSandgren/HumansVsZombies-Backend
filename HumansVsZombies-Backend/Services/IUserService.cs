using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<User> GetUserAsync(int id);
        public Task<User> AddUserAsync(User user);
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(int id);
        public bool UserExists(int id);
    }
}
