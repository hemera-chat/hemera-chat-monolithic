using Hemera.Chat.Domain.Abstractions;
using Hemera.Chat.EFCore.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Hemera.Chat.EFCore;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEFCore(this IServiceCollection services)
    {
        return services.AddScoped<IMessageRepository, MessageRepository>();
    }
}
