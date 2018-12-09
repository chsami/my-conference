using ConferenceApi.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Types
{
    public class CategoryEnumType : EnumerationGraphType
    {
        public CategoryEnumType()
        {
            Name = "Category";
            Description = "Conference Category";
            Description = "User gender";
            var categories = Enum.GetValues(typeof(Category));
            for (int i = 0; i < categories.Length; i++)
            {
                AddValue(categories.GetValue(i).ToString(), "", i);
            }
        }
    }
}
