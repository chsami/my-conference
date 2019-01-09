using ConferenceApi.Domain;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Types
{
    public class LocationType : ObjectGraphType<Location>
    {
        public LocationType()
        {
            Field(m => m.Country);
            Field(m => m.City);
            Field(m => m.Address, type: typeof(AddressType));
        }
    }
}
