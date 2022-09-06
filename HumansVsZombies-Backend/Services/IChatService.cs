using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public interface IChatService
    {
        public Task<IEnumerable<Chat>> GetAllChatsAsync();
        public Task<Chat> GetChatAsync(int id);
        public Task<Chat> AddChatAsync(Chat chat);
        public Task UpdateChatAsync(Chat chat);
        public Task DeleteChatAsync(int id);
        public bool ChatExists(int id);

    }
}
