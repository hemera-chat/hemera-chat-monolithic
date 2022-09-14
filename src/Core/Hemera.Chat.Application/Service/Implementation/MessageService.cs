using Hemera.Chat.Domain.Abstractions;
using Hemera.Chat.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hemera.Chat.Service;
public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;

    public MessageService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
    }

    public Task DeleteMessageAsync(Message message)
    {
        return Task.CompletedTask;
    }

    public async Task SaveMessageAsync(Message message)
    {
        await _messageRepository.AddAsyn(message);        
    }

    public async Task<List<Message>> FetchHistoriesAsync(string userId)
    {
        return await _messageRepository.GetAll().Where(m =>  m.Sender == userId || m.Receiver == userId).OrderBy(m => m.CreatedDate).ToListAsync();
    }
}