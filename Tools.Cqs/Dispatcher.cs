using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace Tools.Cqs
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _provider;

        public Dispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ICommandResult Dispatch(ICommandDefinition command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType)!;
            ICommandResult result = handler.Execute((dynamic)command);

            return result;
        }

        public IQueryResult<T> Dispatch<T>(IQueryDefinition<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType)!;
            IQueryResult<T> result = handler.Execute((dynamic)query);

            return result;
        }
    }
}
