using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface ISessionRepository
    {
        void AddSession(Session session);
        void UpdateSession(Session session);
        void DeleteSession(int sessionId);
        Session GetSessionById(int sessionId);
    }
}