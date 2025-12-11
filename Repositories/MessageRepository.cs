using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Api.Models;

namespace CodeChallenge.Api.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly List<Message> _messages = new();

        public Task AddAsync(Message message)
        {
            _messages.Add(message);
            return Task.CompletedTask; 
        }

        public Task UpdateAsync(Message message)
        {
            var existing = _messages.FirstOrDefault(m => m.Id == message.Id);
            if (existing != null)
            {
                existing.Content = message.Content;
                existing.IsActive = message.IsActive;
                existing.UpdatedAt = message.UpdatedAt;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _messages.RemoveAll(m => m.Id == id);
            return Task.CompletedTask;
        }

        public Task<Message> GetByIdAsync(Guid id)
        {
            var message = _messages.FirstOrDefault(m => m.Id == id);
            return Task.FromResult(message); 
        }

        public Task<IEnumerable<Message>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Message>>(_messages);
        }
    }
}
