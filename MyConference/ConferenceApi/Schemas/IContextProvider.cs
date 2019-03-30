using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Schemas
{
    public interface IContextProvider
    {
        T Get<T>();
    }
}
