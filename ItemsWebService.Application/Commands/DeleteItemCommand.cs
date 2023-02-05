using ItemsWebService.Shared.Abstractions.Commands;

namespace ItemsWebService.Application.Commands
{
    public record DeleteItemCommand(int id) : ICommand;
}
