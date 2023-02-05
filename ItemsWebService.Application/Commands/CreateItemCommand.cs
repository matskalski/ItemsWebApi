using ItemsWebService.Shared.Abstractions.Commands;

namespace ItemsWebService.Application.Commands
{
    public record CreateItemCommand(int Id, string Name, string Code, short ColorId, string Comment) : ICommand;
}
