using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceApi.Domain;
using ConferenceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApi.Store
{
    public class DataStore : IDatastore
    {

        private readonly ConferenceContext _conferenceContext;

        public DataStore(ConferenceContext conferenceContext)
        {
            _conferenceContext = conferenceContext;
        }

        public async Task<List<Conference>> GetAllConferencesAsync()
        {
            var conferences = await _conferenceContext.Conference.ToListAsync();
            return conferences;
        }

        public async Task<Conference> GetConferenceAsync(Guid Id)
        {
            var conference = await _conferenceContext.Conference.FirstOrDefaultAsync(x => x.Id == Id);
            return conference;
        }

        public async Task<Guid> AddConferenceAsync(Conference conference)
        {
            conference.Date = DateTime.UtcNow;
            var conferenceAdded = await _conferenceContext.Conference.AddAsync(conference);

            await _conferenceContext.SaveChangesAsync();

            return conferenceAdded.Entity.Id;
        }

        public async Task<Guid> DeleteConferenceAsync(Guid Id)
        {
            var conferenceToDelete = await _conferenceContext.Conference.FirstOrDefaultAsync(x => x.Id == Id);
            if (conferenceToDelete != null)
            {
                _conferenceContext.Conference.Remove(conferenceToDelete);
                await _conferenceContext.SaveChangesAsync();
            }
            return conferenceToDelete.Id;
        }

        public async Task<Guid> EditConferenceAsync(Conference conference)
        {
            var conferenceToEdit = await _conferenceContext.Conference.FirstOrDefaultAsync(x => x.Id == conference.Id);
            if (conferenceToEdit == null)
            {
                // conference not found exception
            }

            //automapper here?
            conferenceToEdit.Name = conference.Name;
            conferenceToEdit.Url = conference.Url;
            conferenceToEdit.Location = conference.Location;
            conferenceToEdit.Category = conference.Category;

            var conferenceUpdated = _conferenceContext.Conference.Update(conferenceToEdit);

            await _conferenceContext.SaveChangesAsync();

            return conferenceUpdated.Entity.Id;
        }
    }
}
