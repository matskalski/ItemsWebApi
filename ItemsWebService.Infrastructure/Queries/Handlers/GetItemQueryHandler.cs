using ItemsWebService.Application.Dto;
using ItemsWebService.Application.Queries;
using ItemsWebService.Infrastructure.EntityFramework.Contexts;
using ItemsWebService.Infrastructure.EntityFramework.Models;
using ItemsWebService.Infrastructure.Exceptions;
using ItemsWebService.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace ItemsWebService.Infrastructure.Queries.Handlers
{
    internal class GetItemQueryHandler : IQueryHandler<GetItemQuery, ItemDto>
    {
        private readonly DbSet<ItemReadModel> _items;

        public GetItemQueryHandler(ReadAppDbContext context)
        {
            _items = context.Items;
        }

        public async Task<ItemDto> Handle(GetItemQuery query)
        {
            var item = await _items
                        .Include(i => i.Color)
                        .Where(w => w.Id == query.Id)
                        .Select(s => s.AsDto())
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

            if (item is null)
            {
                throw new ItemDoesNotExistsException(query.Id);
            }

            return item;
        }
    }
}
