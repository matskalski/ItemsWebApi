using ItemsWebService.Application.Dto;
using ItemsWebService.Shared.Abstractions.Queries;

namespace ItemsWebService.Application.Queries
{
    public record GetItemQuery(int Id) : IQuery<ItemDto>;
}
