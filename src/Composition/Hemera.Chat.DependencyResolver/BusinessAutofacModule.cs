using Autofac;
using Hemera.Chat.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Hemera.Chat.DependencyResolver
{
    public static class BusinessAutofacModule
    {
        public static ContainerBuilder CreateAutofacBusinessContainer(this IServiceCollection services, ContainerBuilder builder)
        {
            builder.RegisterType<IChatService>().As<ChatService>();
            //builder.RegisterType<IMessageServiceQuery>().As<MessageServiceQuery>();
            return builder;
        }
    }

    public class BusinessAutofacModule1 : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ChatService>().As<IChatService>();
            //builder.RegisterType<MessageServiceQuery>().As<IMessageServiceQuery>();
        }
    }
}
