using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        }

        public void UpdateConference(Conference conference)
        {

        }

        public void DeleteConference(Conference conference)
        {

        }

        public Conference GetConferenceById(int conferenceId)
        {
            return null;
        }
    }
}