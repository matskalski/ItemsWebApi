using ItemsWebService.Application.Exceptions;
using ItemsWebService.Application.Services;
using ItemsWebService.Domain.Entities;
using ItemsWebService.Domain.Repositories;
using ItemsWebService.Shared.Abstractions.Commands;

namespace ItemsWebService.Application.Commands.Handlers
{
    internal class CreateItemCommandHandler : IcommandHandler<CreateItemCommand>
    {
        private readonly IItemsService _itemsService;
        private readonly IItemsRepository _itemsRespository;
        private readonly IColorsRepository _colorsRepository;

        public CreateItemCommandHandler(IItemsService itemsService, IItemsRepository itemsRespository, IColorsRepository colorsRepository)
        {
            _itemsService = itemsService;
            _itemsRespository = itemsRespository;
            _colorsRepository = colorsRepository;
        }

        public async Task Handle(CreateItemCommand commnad)
        {
            var (id, name, code, colorId, comment) = commnad;

            if (await _itemsService.ExistisByCode(code))
            {
                throw new ItemWithKeyAlreadyExistsException(code);
            }

            var color = await _colorsRepository.GetById(colorId);

            var item = Item.Create(id, name, code, color, comment);

            await _itemsRespository.AddItem(item);
        }
    }
}
