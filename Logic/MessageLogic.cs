using CodeChallenge.Api.Models;
using CodeChallenge.Api.Repositories;

namespace CodeChallenge.Api.Logic
{
    public class MessageLogic : IMessageLogic
    {
        private readonly IMessageLogic _messageRepository;
        public MessageLogic(IMessageLogic messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Task<Result> CreateMessageAsync(Guid organizationId, CreateMessageRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> DeleteMessageAsync(Guid organizationId, Guid id)
        {
            var message = await _messageRepository.GetMessageAsync(organizationId, id);

            if (message == null)
                return new NotFound("Message not found.");

            if (!message.IsActive)
                return new ValidationError(new Dictionary<string, string[]>
        {
            { "IsActive", new[] { "Cannot delete an inactive message." } }
        });

            var deleted = await _messageRepository.DeleteMessageAsync(organizationId, id);

            return deleted != null ? new Deleted() : new NotFound("Message could not be deleted.");
        }


        public async Task<IEnumerable<Message>> GetAllMessagesAsync(Guid organizationId)
        {
            var messages = await _messageRepository.GetAllMessagesAsync(organizationId);
            return messages.Where(m => m.IsActive);
        }

        public async Task<Message?> GetMessageAsync(Guid organizationId, Guid id)
        {
            var message = await _messageRepository.GetMessageAsync(organizationId, id);
            return message?.IsActive == true ? message : null;
        }

        public async Task<Result> UpdateMessageAsync(Message message)
        {
            var updatedMessage = await _messageRepository.UpdateMessageAsync(message);

            return updatedMessage != null ? new Updated() : new NotFound("Message could not be updated.");
        }



    }
}
