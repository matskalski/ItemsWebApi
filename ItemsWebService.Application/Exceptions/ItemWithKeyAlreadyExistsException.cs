using ItemsWebService.Shared.Abstractions.Exceptions;

namespace ItemsWebService.Application.Exceptions
{
    internal class ItemWithKeyAlreadyExistsException : ItemWebServiceException
    {
        public string Code { get; }
        public ItemWithKeyAlreadyExistsException(string code) : base($"Item with code {code} already exists")
        {
            Code = code;
        }
    }
}
