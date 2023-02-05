using ItemsWebService.Shared.Abstractions.Commands;
using ItemsWebService.Shared.Abstractions.Queries;
using ItemsWebService.Shared.Implementations.Commands;
using ItemsWebService.Shared.Implementations.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ItemsWebService.Shared
{
    public static class Extensions
    {
        private static Assembly assembly = Assembly.GetCallingAssembly();

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IcommandHandler<>)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
