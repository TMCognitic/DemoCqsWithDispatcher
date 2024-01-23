using DemoCqsWithDispatcher.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Queries;

namespace DemoCqsWithDispatcher.Models.Queries
{
    public class GetAllContactQuery : IQueryDefinition<IEnumerable<Contact>>
    {
    }

    public class GetAllContactQueryHandler : IQueryHandler<GetAllContactQuery, IEnumerable<Contact>>
    {
        private readonly IList<Contact> _contacts;

        public GetAllContactQueryHandler(IList<Contact> contacts)
        {
            _contacts = contacts;
        }

        public IQueryResult<IEnumerable<Contact>> Execute(GetAllContactQuery query)
        {
            return IQueryResult<IEnumerable<Contact>>.Success(_contacts);
        }
    }
}
