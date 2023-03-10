namespace ItemsWebService.Shared.Abstractions.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> Query<TResult>(IQuery<TResult> query);
    }
}
