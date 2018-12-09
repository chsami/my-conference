using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Types
{
    public class ConferenceInputType : InputObjectGraphType
    {
        public ConferenceInputType()
        {
            Name = "ConferenceInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("url");
            Field<StringGraphType>("location");
            Field<CategoryEnumType>("category");

        }
    }
}
