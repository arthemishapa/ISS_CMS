using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly CMSDbContext context;

        public SessionRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public void AddSession(Session session)
        {

        }

        public void UpdateSession(Session session)
        {

        }

        public void DeleteSession(Session session)
        {

        }

        public Session GetSessionById(int sessionId)
        {
            return null;
        }
    }
}