using ItemsWebService.Shared.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace ItemsWebService.Shared.Implementations.Commands
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        async Task ICommandDispatcher.Dispatch<TCommand>(TCommand command)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService<IcommandHandler<TCommand>>();

                await handler.Handle(command);
            }
        }
    }
}
