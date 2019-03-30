using ConferenceApi.Mutations;
using ConferenceApi.Queries;
using ConferenceApi.Schemas.Mutations;
using ConferenceApi.Schemas.Queries;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Schemas
{
    public class ConferenceSchema : Schema
    {
        public ConferenceSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<RootQuery>();
            Mutation = resolver.Resolve<RootMutation>();
        }
    }
}
