using Microsoft.Extensions.DependencyInjection;

namespace Hemera.Chat.Domain;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}
