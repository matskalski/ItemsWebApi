namespace ItemsWebService.Shared.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
