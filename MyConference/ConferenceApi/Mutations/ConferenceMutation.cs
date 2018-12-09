using ConferenceApi.Models;
using ConferenceApi.Store;
using ConferenceApi.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Mutations
{
    public class ConferenceMutation : ObjectGraphType
    {
        public ConferenceMutation(IDatastore dataStore)
        {
            Field<IdGraphType>(
                   "addConference",
                   arguments: new QueryArguments(
                       new QueryArgument<NonNullGraphType<ConferenceInputType>> { Name = "conferencelol" }
                   ),
                   resolve: context =>
                   {
                       var conference = context.GetArgument<Conference>("conferencelol");
                       return dataStore.AddConferenceAsync(conference);
                   });
        }
    }
}
