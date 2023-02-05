using ItemsWebService.Shared.Abstractions.Exceptions;

namespace ItemsWebService.Domain.Exceptions
{
    internal class InvalidColorNameException : ItemWebServiceException
    {
        public InvalidColorNameException(string message) : base(message)
        {
        }
    }
}
