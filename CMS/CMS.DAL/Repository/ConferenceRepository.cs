using System.Collections.Generic;
using System.Linq;

using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;
using System.Data.Entity;

namespace CMS.CMS.DAL.Repository
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly CMSDbContext context;

        public ConferenceRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public Conference AddConference(Conference conference)
        {
            var addedConference = context.Conferences.Add(conference);
            context.SaveChanges();
            return addedConference;
        }

        public void UpdateConference(Conference conference)
        {
            var conferenceToUpdate = GetConferenceById(conference.Id);

            conferenceToUpdate.StartDate = conference.StartDate;
            conferenceToUpdate.EndDate = conference.EndDate;
            conferenceToUpdate.AbstractPaperDeadline = conference.AbstractPaperDeadline;
            conferenceToUpdate.ProposalPaperDeadline = conference.ProposalPaperDeadline;
            conferenceToUpdate.BiddingDeadline = conference.BiddingDeadline;

            context.SaveChanges();
        }

        public Conference GetConferenceById(int conferenceId)
        {
            return context.Conferences.Include(a => a.Chair).SingleOrDefault(c => c.Id == conferenceId);
        }

        public IEnumerable<Conference> GetAll()
        {   
            return context.Conferences.Include(a => a.Chair).ToList();
        }
    }
}