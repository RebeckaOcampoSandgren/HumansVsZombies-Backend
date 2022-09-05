using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public class ChatService : IChatService
    {
        private readonly HvZDbContext _context;

        public ChatService(HvZDbContext context)
        {
            _context = context;
        }

        public Task<Chat> AddChatAsync(Chat chat)
        {
            throw new NotImplementedException();
        }

        public bool ChatExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteChatAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Chat>> GetAllChatsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Chat> GetChatAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateChatAsync(Chat chat)
        {
            throw new NotImplementedException();
        }
    }
}
