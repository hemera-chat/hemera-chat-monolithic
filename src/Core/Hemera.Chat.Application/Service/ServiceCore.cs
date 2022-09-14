using System.Reflection;

namespace Hemera.Chat.Application.Service
{
    public static class ServiceCore
    {
        /// <summary>
        ///Get assembly name
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}
