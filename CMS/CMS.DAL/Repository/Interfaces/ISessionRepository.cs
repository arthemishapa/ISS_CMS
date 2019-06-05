using System.Collections.Generic;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface ISessionRepository
    {
        Session AddSession(Session session);
        IEnumerable<Session> GetAll();
    }
}