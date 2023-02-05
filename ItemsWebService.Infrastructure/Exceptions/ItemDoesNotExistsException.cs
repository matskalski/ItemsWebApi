using ItemsWebService.Shared.Abstractions.Exceptions;

namespace ItemsWebService.Infrastructure.Exceptions
{
    internal class ItemDoesNotExistsException : ItemWebServiceException
    {
        public int Id { get; }
        public ItemDoesNotExistsException(int id) : base($"Item with id {id} does not exists")
        {
            Id = id;
        }
    }
}
