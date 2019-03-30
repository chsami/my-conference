using ConferenceApi.Domain;
using ConferenceApi.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Types
{
    public class CategoryEnumType : EnumerationGraphType<Category>
    {
    }
}
