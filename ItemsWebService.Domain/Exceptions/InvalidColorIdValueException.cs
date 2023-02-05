using ItemsWebService.Shared.Abstractions.Exceptions;

namespace ItemsWebService.Domain.Exceptions
{
    internal class InvalidColorIdValueException : ItemWebServiceException
    {
        public InvalidColorIdValueException() : base("ClolorId value has to be greater then 0")
        {
        }
    }
}
