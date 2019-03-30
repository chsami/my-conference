using ConferenceApi.Models;
using ConferenceApi.Schemas;
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
    public class ConferenceQuery : ObjectGraphType<object>
    {
        private readonly IContextProvider _contextProvider;

        public ConferenceQuery(IContextProvider contextProvider)
        {
            _contextProvider = contextProvider;

            Field<ListGraphType<ConferenceType>>()
                .Name("Conferences")
                .ResolveAsync(async context =>
                {
                    var dataStore = _contextProvider.Get<IDatastore>();
                    return await dataStore.GetAllConferencesAsync();
                });

            Field<ConferenceType>()
                .Name("Conference")
                //Arguments???
                .Argument<NonNullGraphType<IdGraphType>>("id", "id of the conference")
                .ResolveAsync(async context =>
                {
                    var dataStore = _contextProvider.Get<IDatastore>();
                    return await dataStore.GetConferenceAsync(new Guid(context.GetArgument<string>("id")));
                });

            Field<StringGraphType>(name: "hello", resolve: context => "world");

        }

    }
}
