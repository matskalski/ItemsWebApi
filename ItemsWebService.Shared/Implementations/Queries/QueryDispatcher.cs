using ItemsWebService.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace ItemsWebService.Shared.Implementations.Queries
{
    internal class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> Query<TResult>(IQuery<TResult> query)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
                var handler = scope.ServiceProvider.GetRequiredService(handlerType);

                return await (Task<TResult>)handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.Handle))?.Invoke(handler, new[] { query });
            }
        }
    }
}
