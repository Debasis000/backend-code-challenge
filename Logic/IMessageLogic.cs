using CodeChallenge.Api.Models;

namespace CodeChallenge.Api.Logic;

public interface IMessageLogic
{

    Task<Message> CreateMessageAsync(Message message);
    Task<Message?> GetMessageAsync(Guid id);
    Task<Message?> UpdateMessageAsync(Guid id, UpdateMessageDto dto);
    Task<bool> DeleteMessageAsync(Guid id);
  
}


