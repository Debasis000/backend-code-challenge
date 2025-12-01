using CodeChallenge.Api.Models;
using CodeChallenge.Api.Repositories;

namespace CodeChallenge.Api.Logic
{
    public class MessageLogic : IMessageLogic
    {
        private readonly IMessageRepository _messageRepository;

       
        public MessageLogic(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message> CreateMessageAsync(Message message)
        {
           
            if (string.IsNullOrWhiteSpace(message.Content))
                throw new ArgumentException("Content is required");

            return await _messageRepository.CreateAsync(message);
        }

        public async Task<Message?> GetMessageAsync(Guid id)
        {
            
            return await _messageRepository.GetByIdAsync(id);
        }

        public async Task<Message?> UpdateMessageAsync(Guid id, UpdateMessageDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Content))
                throw new ArgumentException("Content is required");

            var message = new Message { Content = dto.Content };
            
            return await _messageRepository.UpdateAsync(id, message);
        }

        public async Task<bool> DeleteMessageAsync(Guid id)
        {
           
            return await _messageRepository.DeleteAsync(id);
        }


    }
}
