using ConferenceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Store
{
    public interface IDatastore
    {
        Task<List<Conference>> GetAllConferencesAsync();
        Task<Conference> GetConferenceAsync(Guid Id);
        Task<Guid> AddConferenceAsync(Conference conference);
    }
}
