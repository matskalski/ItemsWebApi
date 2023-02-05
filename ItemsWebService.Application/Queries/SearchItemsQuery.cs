using ItemsWebService.Application.Dto;
using ItemsWebService.Shared.Abstractions.Queries;

namespace ItemsWebService.Application.Queries
{
    public class SearchItemsQuery : IQuery<IEnumerable<ItemDto>>
    {
        public Func<ItemDto, bool> Predicate { get; set; }

        public SearchItemsQuery(Func<ItemDto, bool> predicate = null)
        {
            Predicate = predicate;
        }
    }
}
