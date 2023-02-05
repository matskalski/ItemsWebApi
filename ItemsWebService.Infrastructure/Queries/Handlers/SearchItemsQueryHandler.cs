using ItemsWebService.Application.Dto;
using ItemsWebService.Application.Queries;
using ItemsWebService.Infrastructure.EntityFramework.Contexts;
using ItemsWebService.Infrastructure.EntityFramework.Models;
using ItemsWebService.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace ItemsWebService.Infrastructure.Queries.Handlers
{
    public class SearchItemsQueryHandler : IQueryHandler<SearchItemsQuery, IEnumerable<ItemDto>>
    {
        private readonly DbSet<ItemReadModel> _items;

        public SearchItemsQueryHandler(ReadAppDbContext context)
        {
            _items = context.Items;
        }

        public async Task<IEnumerable<ItemDto>> Handle(SearchItemsQuery query)
        {
            var dbQuery = await _items
                .Include(i => i.Color)
                .Select(s => s.AsDto())
                .ToListAsync();

            if (query.Predicate is not null)
            {
                dbQuery = dbQuery.Where(query.Predicate).ToList();
            }

            return dbQuery;
        }
    }
}
