using ConferenceApi.Domain;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Types
{
    public class ConferenceType : ObjectGraphType<Conference>
    {
        public ConferenceType()
        {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Id of a conference");
            Field(f => f.Name).Description("Name of a conference"); ;
            Field(f => f.Url).Description("Website of a conference"); ;
            Field(f => f.Category, type: typeof(NonNullGraphType<CategoryEnumType>)).Description("Category of a conference");
        }
    }
}
