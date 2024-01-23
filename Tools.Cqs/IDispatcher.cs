using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace Tools.Cqs
{
    public interface IDispatcher
    {
        ICommandResult Dispatch(ICommandDefinition command);
        IQueryResult<T> Dispatch<T>(IQueryDefinition<T> query);
    }
}