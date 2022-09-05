using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Chat> AddChatAsync(Chat chat)
        {
            _context.Chat.Add(chat);
            await _context.SaveChangesAsync();
            return chat;
        }

        public bool ChatExists(int id)
        {
            return _context.Chat.Any(e => e.ChatId == id);
        }

        public async Task DeleteChatAsync(int id)
        {
            var chat = await _context.Chat.FindAsync(id);
            _context.Chat.Remove(chat);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Chat>> GetAllChatsAsync()
        {
            return await _context.Chat.ToListAsync();
        }

        public async Task<Chat> GetChatAsync(int id)
        {
            return await _context.Chat.FindAsync(id);
        }

        public async Task UpdateChatAsync(Chat chat)
        {
            _context.Entry(chat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
