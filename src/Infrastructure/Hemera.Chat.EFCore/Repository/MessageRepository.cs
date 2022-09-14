using Hemera.Chat.Domain.Abstractions;
using Hemera.Chat.Entities;
using Hemera.Chat.Repository;

namespace Hemera.Chat.EFCore.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(HemeraChatDbContext context) : base(context)
        {
        }
    }
}
