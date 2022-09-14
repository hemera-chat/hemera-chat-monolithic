using Hemera.Chat.Entities;

namespace Hemera.Chat.Service;
public interface IMessageService
{
    Task SaveMessageAsync(Message message);
    Task DeleteMessageAsync(Message message);
    Task<List<Message>> FetchHistoriesAsync(string userId);
}
