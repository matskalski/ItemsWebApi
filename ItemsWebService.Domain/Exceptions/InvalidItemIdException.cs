using ItemsWebService.Shared.Abstractions.Exceptions;

namespace ItemsWebService.Domain.Exceptions
{
    internal class InvalidItemIdException : ItemWebServiceException
    {
        public InvalidItemIdException() : base("ItemId value has to be greater then 0")
        {
        }
    }
}
