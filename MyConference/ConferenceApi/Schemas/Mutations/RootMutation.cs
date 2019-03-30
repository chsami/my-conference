using ConferenceApi.Mutations;
using GraphQL.Types;

namespace ConferenceApi.Schemas.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Name = "Mutation";
            Field<NonNullGraphType<ConferenceMutation>>().Name("TargetMutation").Resolve(context => new { });
        }
    }
}
