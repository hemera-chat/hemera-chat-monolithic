using Hemera.Chat.Domain.Contracts;
using Hemera.Chat.Enums;

namespace Hemera.Chat.Entities;
public class Message : IEntity
{
    public long Id { get; set; }
    public string UniqueId { get; set; } = null!;
    public string Sender { get; set; } = null!;
    public string Receiver { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string? ReplayFromUniqueId { get; set; }
    public MessageType Type { get; set; }
    public ReactType ReactType { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsSeen { get; set; }
    public bool IsSenderDeleted { get; set; }
    public bool IsReceiverDeleted { get; set; }
    public string? ConnectionId { get; set; }
}