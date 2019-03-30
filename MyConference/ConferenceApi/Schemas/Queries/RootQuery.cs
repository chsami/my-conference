using ConferenceApi.Queries;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Schemas.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Name = "Query";
            Field<NonNullGraphType<ConferenceQuery>>().Name("ConferenceQuery").Resolve(context => new { });
        }
    }
}
