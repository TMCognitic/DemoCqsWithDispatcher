using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Cqs.Queries
{
    public interface IQueryHandler<TQuery, T>
        where TQuery : class, IQueryDefinition<T>
    {
        IQueryResult<T> Execute(TQuery query);
    }
}
