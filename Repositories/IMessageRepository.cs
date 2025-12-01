using CodeChallenge.Api.Models;

namespace CodeChallenge.Api.Repositories;

public interface IMessageRepository
{

    Task<Message?> GetByIdAsync(Guid id);
    Task<Message> CreateAsync(Message message);
    Task<Message?> UpdateAsync(Guid id, Message message);
    Task<bool> DeleteAsync(Guid id);
    
}
