using System.Collections.Generic;
using System.Linq;

using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly CMSDbContext context;

        public ConferenceRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public void AddConference(Conference conference)
        {
            context.Conferences.Add(conference);
            context.SaveChanges();
        }

        public void UpdateConference(Conference conference)
        {

        }

        public void DeleteConference(int conferenceId)
        {
        }

        public Conference GetConferenceById(int conferenceId)
        {
            return context.Conferences.SingleOrDefault(c => c.Id == conferenceId);
        }

        public IEnumerable<Conference> GetAll()
        {   
            return context.Conferences.ToList();
        }
    }
}