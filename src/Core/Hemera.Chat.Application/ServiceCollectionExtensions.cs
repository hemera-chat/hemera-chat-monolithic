using Hemera.Chat.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Hemera.Chat.Application;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddScoped<IMessageService, MessageService>()
            .AddScoped<IContactService, ContactService>();
    }
}