using CodeChallenge.Api.Models;

namespace CodeChallenge.Api.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        private readonly List<Message> _messages = new();
        private static int _nextId = 1; 

        public async Task<Message?> GetByIdAsync(Guid id)
        {
            await Task.Delay(1); 
            return _messages.FirstOrDefault(m => m.Id == id);
        }

        public async Task<Message> CreateAsync(Message message)
        {
            if (message.Id == Guid.Empty)
                message.Id = Guid.NewGuid();
            if (message.CreatedAt == default)
                message.CreatedAt = DateTime.UtcNow;
            _messages.Add(message);
            await Task.Delay(1);
            return message;
        }

        public async Task<Message?> UpdateAsync(Guid id, Message message)
        {
            var existing = _messages.FirstOrDefault(m => m.Id == id);
            if (existing == null) return null;
            existing.Content = message.Content;
            await Task.Delay(1);
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = _messages.FirstOrDefault(m => m.Id == id);
            if (existing == null) return false;
            _messages.Remove(existing);
            await Task.Delay(1);
            return true;
        }
    }
}
