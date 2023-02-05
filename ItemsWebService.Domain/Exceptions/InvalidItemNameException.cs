using ItemsWebService.Shared.Abstractions.Exceptions;

namespace ItemsWebService.Domain.Exceptions
{
    internal class InvalidItemNameException : ItemWebServiceException
    {
        public InvalidItemNameException(string message) : base(message)
        {
        }
    }
}
