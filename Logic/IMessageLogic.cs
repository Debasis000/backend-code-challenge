using CodeChallenge.Api.Models;

namespace CodeChallenge.Api.Logic;

public interface IMessageLogic
{
    Task<Message> GetByIdAsync(Guid id);
    Task<Message> CreateAsync(CreateMessageRequest request);
    Task<Message> UpdateMessageAsync(Guid id, UpdateMessageRequest request);
    Task<bool> DeleteAsync(Guid id);
}


