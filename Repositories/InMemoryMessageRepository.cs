using CodeChallenge.Api.Models;
using System.Collections.Concurrent;

namespace CodeChallenge.Api.Repositories;

public class InMemoryMessageRepository : IMessageRepository
{
    private readonly ConcurrentDictionary<Guid, Message> _store = new();

    public Task AddAsync(Message message)
    {
        _store[message.Id] = message;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        _store.TryRemove(id, out _);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Message>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Message>>(_store.Values.ToList());
    }

    public Task<Message> GetByIdAsync(Guid id)
    {
        _store.TryGetValue(id, out var message);
        return Task.FromResult(message);
    }

    public Task UpdateAsync(Message message)
    {
        _store[message.Id] = message;
        return Task.CompletedTask;
    }
}
