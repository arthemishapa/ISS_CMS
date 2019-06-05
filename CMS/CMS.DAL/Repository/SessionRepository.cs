using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public Session AddSession(Session session)
        {
            var addedSession = context.Sessions.Add(session);
            context.SaveChanges();

            return addedSession;
        }

        public IEnumerable<Session> GetAll()
        {
            return context.Sessions.Include(s => s.Chair).ToList();
        }
    }
}