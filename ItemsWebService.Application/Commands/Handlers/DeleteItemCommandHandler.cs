using ItemsWebService.Application.Exceptions;
using ItemsWebService.Domain.Repositories;
using ItemsWebService.Shared.Abstractions.Commands;

namespace ItemsWebService.Application.Commands.Handlers
{
    internal class DeleteItemCommandHandler : IcommandHandler<DeleteItemCommand>
    {
        private readonly IItemsRepository _itemsRespository;

        public DeleteItemCommandHandler(IItemsRepository itemsRespository)
        {
            _itemsRespository = itemsRespository;
        }

        public async Task Handle(DeleteItemCommand commnad)
        {
            var item = await _itemsRespository.GetItem(commnad.id);

            if (item is null)
            {
                throw new ItemWithIdDoNotExistsException(commnad.id);
            }

            await _itemsRespository.DeleteItem(commnad.id);
        }
    }
}
