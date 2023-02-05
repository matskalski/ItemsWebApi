using ItemsWebService.Application.Exceptions;
using ItemsWebService.Application.Services;
using ItemsWebService.Domain.Repositories;
using ItemsWebService.Shared.Abstractions.Commands;

namespace ItemsWebService.Application.Commands.Handlers
{
    internal class UpdateItemCommandHandler : IcommandHandler<UpdateItemCommand>
    {
        private readonly IItemsService _itemsService;
        private readonly IItemsRepository _itemsRespository;
        private readonly IColorsRepository _colorsRepository;

        public UpdateItemCommandHandler(IItemsService itemsService, IItemsRepository itemsRespository, IColorsRepository colorsRepository)
        {
            _itemsService = itemsService;
            _itemsRespository = itemsRespository;
            _colorsRepository = colorsRepository;
        }

        public async Task Handle(UpdateItemCommand commnad)
        {
            var (id, name, code, colorId, comment) = commnad;

            if (await _itemsService.ExistisByCode(code))
            {
                throw new ItemWithKeyAlreadyExistsException(code);
            }

            var item = await _itemsRespository.GetItem(id);
            if (item is null)
            {
                throw new ItemWithIdDoNotExistsException(id);
            }

            var color = await _colorsRepository.GetById(colorId);

            item.Update(name, code, color, comment);
        }
    }
}
