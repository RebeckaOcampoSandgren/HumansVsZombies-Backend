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
        public Task<User> GetUserAsync(string id);
        public Task<User> AddUserAsync(User user);
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(string id);
        public bool UserExists(string id);
    }
}
