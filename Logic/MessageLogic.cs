using CodeChallenge.Api.Models;
using CodeChallenge.Api.Repositories;

namespace CodeChallenge.Api.Logic
{
    public class MessageLogic : IMessageLogic
    {
        private readonly IMessageRepository _repo;

        public MessageLogic(IMessageRepository repo)
        {
            _repo = repo;
        }

        public async Task<Message> CreateAsync(CreateMessageRequest request)
        {
            var entity = new Message
            {
                Content = request.Content,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(entity);
            return entity;
        }

        public async Task<Message> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<Message> UpdateMessageAsync(Guid id, UpdateMessageRequest request)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

          
            existing.Content = request.Content;
            existing.UpdatedAt = DateTime.UtcNow;

            await _repo.UpdateAsync(existing);
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }


    }
}
