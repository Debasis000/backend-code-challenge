using CodeChallenge.Api.Data;
using CodeChallenge.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Api.Repositories
{
    public class EfMessageRepository : IMessageRepository
    {
        private readonly AppDbContext _db;

        public EfMessageRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Message message)
        {
            await _db.Messages.AddAsync(message);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _db.Messages.FindAsync(id);
            if (entity == null) return;
            _db.Messages.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await _db.Messages.AsNoTracking().ToListAsync();
        }

        public async Task<Message> GetByIdAsync(Guid id)
        {
            return await _db.Messages.FindAsync(id);
        }

        public async Task UpdateAsync(Message message)
        {
           
            _db.Messages.Update(message);
            await _db.SaveChangesAsync();
        }
    }
}
