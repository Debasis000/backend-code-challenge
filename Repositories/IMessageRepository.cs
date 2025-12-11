using CodeChallenge.Api.Models;

namespace CodeChallenge.Api.Repositories;

public interface IMessageRepository
{
    Task AddAsync(Message message);
    Task UpdateAsync(Message message);
    Task DeleteAsync(Guid id);
    Task<Message> GetByIdAsync(Guid id);
    Task<IEnumerable<Message>> GetAllAsync();
}
