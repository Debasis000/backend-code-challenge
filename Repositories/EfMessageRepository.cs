using CodeChallenge.Api.Data;
using CodeChallenge.Api.Models;

namespace CodeChallenge.Api.Repositories
{
    public class EfMessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;

        public EfMessageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Message?> GetByIdAsync(Guid id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<Message> CreateAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<Message?> UpdateAsync(Guid id, Message message)
        {
            var existing = await _context.Messages.FindAsync(id);
            if (existing == null) return null;

            existing.Content = message.Content;
            

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _context.Messages.FindAsync(id);
            if (existing == null) return false;

            _context.Messages.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
