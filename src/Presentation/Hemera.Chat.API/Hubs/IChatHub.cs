using Hemera.Chat.Domain.Dtos;
using Hemera.Chat.Entities;

namespace HemeraChat.Hubs;
public interface IChatHub
{
    Task OnConnectedAsync();
    Task OnDisconnectedAsync(Exception? exception);
    Task SendDirectMessage(Message message, OriginType originType);
}
