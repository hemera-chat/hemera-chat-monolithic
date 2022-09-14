using Hemera.Chat.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using Hemera.Chat.Service;
using Hemera.Chat.Domain.Dtos;
using HemeraChat.Hubs;

namespace Hemera.Chat.Hubs;

[Authorize]
public class ChatHub : Hub//, IChatHub
{
    private readonly IMessageService _chatService;
    private readonly static ConnectionMapping<string> _connections =
        new ConnectionMapping<string>();

    public ChatHub(IMessageService chatService)
    {
        _chatService = chatService ?? throw new ArgumentNullException(nameof(chatService));
    }

    public async Task SendDirectMessage(Message message)
    {
        string? userId = Context?.UserIdentifier;

        if (message.Sender != null && message.Sender == userId)
        {
            message.UniqueId = Guid.NewGuid().ToString();

            foreach (var connectionId in _connections.GetConnections(message.Receiver))
            {
                await Clients.Client(connectionId).SendAsync("ReceivedMessage", message);
            }

            await _chatService.SaveMessageAsync(message);
        }
        else
        {
            // TODO: Logged It
        }
    }

    public override async Task OnConnectedAsync()
    {
        string userId = Context?.UserIdentifier!;
        string connectionId = Context?.ConnectionId!;

        _connections.Add(userId, connectionId);

        await FetchChatHistoriesAsync(userId);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        string? name = Context?.User?.Identity?.Name!;
        string connectionId = Context?.ConnectionId!;

        _connections.Remove(name, connectionId);

        await base.OnDisconnectedAsync(exception);
    }

    private async Task FetchChatHistoriesAsync(string userId)
    {
        var messages = await _chatService.FetchHistoriesAsync(userId);

        foreach (var message in messages)
        {
            foreach (var connectionId in _connections.GetConnections(userId))
            {
                await Clients.Client(connectionId).SendAsync("ReceivedMessage", message);
            }
        }
    }
}