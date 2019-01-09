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
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Id of the conference");
            Field(f => f.Name);
            Field(f => f.Location, type: typeof(LocationType));
            Field(f => f.Date);
            Field(f => f.Url);
        }
    }
}
