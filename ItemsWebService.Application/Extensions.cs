using ItemsWebService.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace ItemsWebService.Application
{
    internal static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            return services;
        }
    }
}
