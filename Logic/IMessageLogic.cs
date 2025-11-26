using CodeChallenge.Api.Models;

namespace CodeChallenge.Api.Logic;

public interface IMessageLogic
{
    Task<Result> CreateMessageAsync(Guid organizationId, CreateMessageRequest request);
    Task<Result> UpdateMessageAsync(Message message);
    Task<Result> DeleteMessageAsync(Guid organizationId, Guid id);
    Task<Message?> GetMessageAsync(Guid organizationId, Guid id);
    Task<IEnumerable<Message>> GetAllMessagesAsync(Guid organizationId);
}
