using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface ISessionRepository
    {
        void AddSession(Session session);
        void UpdateSession(Session session);
        void DeleteSession(Session session);
        Session GetSessionById(int sessionId);
    }
}