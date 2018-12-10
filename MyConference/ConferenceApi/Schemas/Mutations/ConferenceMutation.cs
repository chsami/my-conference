﻿using ConferenceApi.Domain;
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
                       new QueryArgument<NonNullGraphType<ConferenceInputType>> { Name = "conference" }
                   ),
                   resolve: context =>
                   {
                       var conference = context.GetArgument<Conference>("conference");
                       return dataStore.AddConferenceAsync(conference);
                   });

            Field<IdGraphType>(
                   "deleteConference",
                   arguments: new QueryArguments(
                       new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                   ),
                   resolve: context =>
                   {
                       var conferenceId = context.GetArgument<Guid>("id");
                       return dataStore.DeleteConferenceAsync(conferenceId);
                   });

            Field<IdGraphType>(
                  "editConference",
                  arguments: new QueryArguments(
                      new QueryArgument<NonNullGraphType<ConferenceInputType>> { Name = "conference" }
                  ),
                  resolve: context =>
                  {
                      var conference = context.GetArgument<Conference>("conference");
                      return dataStore.EditConferenceAsync(conference);
                  });
        }
    }
}
