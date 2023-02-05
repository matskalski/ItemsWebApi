namespace ItemsWebService.Shared.Abstractions.Commands
{
    public interface IcommandHandler<in TCommnad> where TCommnad : class, ICommand
    {
        Task Handle(TCommnad commnad);
    }
}
