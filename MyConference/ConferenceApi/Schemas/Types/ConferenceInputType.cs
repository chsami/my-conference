using ConferenceApi.Domain;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Types
{
    public class ConferenceInputType : InputObjectGraphType<Conference>
    {
        public ConferenceInputType()
        {
            Name = "ConferenceInput";
            Field(f => f.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(f => f.Name);
            Field(f => f.Url);
            Field(f => f.Location);
            Field(f => f.Category, type: typeof(NonNullGraphType<CategoryEnumType>));
        }
    }
}
