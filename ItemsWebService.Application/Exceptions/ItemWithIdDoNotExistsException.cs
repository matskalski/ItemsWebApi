using ItemsWebService.Shared.Abstractions.Exceptions;

namespace ItemsWebService.Application.Exceptions
{
    internal class ItemWithIdDoNotExistsException : ItemWebServiceException
    {
        public int Id { get; }
        public ItemWithIdDoNotExistsException(int id) : base($"Item with id {id} do not exists")
        {
            Id = id;
        }
    }
}
