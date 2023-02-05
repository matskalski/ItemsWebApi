namespace ItemsWebService.Shared.Abstractions.Exceptions
{
    public abstract class ItemWebServiceException : Exception
    {
        protected ItemWebServiceException(string message) : base(message) { }
    }
}
