using ItemsWebService.Shared.Abstractions.Exceptions;

namespace ItemsWebService.Domain.Exceptions
{
    internal class InvalidItemCodeException : ItemWebServiceException
    {
        public InvalidItemCodeException(string message) : base(message)
        {
        }
    }
}
