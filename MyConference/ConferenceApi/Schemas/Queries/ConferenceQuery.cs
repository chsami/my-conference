using ConferenceApi.Models;
using ConferenceApi.Store;
using ConferenceApi.Types;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Queries
{
    public class ConferenceQuery : ObjectGraphType
    {

        public ConferenceQuery(IDataLoaderContextAccessor accessor, IDatastore dataStore)
        {
            Field<ListGraphType<ConferenceType>>(
                "Conferences",
                resolve: (context => dataStore.GetAllConferencesAsync())
            );

            Field<ConferenceType>()
                .Name("Conference")
                //Arguments???
                .Argument<NonNullGraphType<IdGraphType>>("id", "id of the conference")
                .ResolveAsync(async context => await dataStore.GetConferenceAsync(new Guid(context.GetArgument<string>("id"))));

            Field<StringGraphType>(name: "hello", resolve: context => "world");

        }

    }
}
