using CMS.CMS.DAL.Repository;

namespace CMS.CMS.DAL
{
    // TODO
    public class UnitOfWork
    {
        public IConferenceRepository ConferenceRepository { get; set; }
        public IRequestRepository RequestRepository { get; set; }
        public IUserRoleRepository UserRolesRepository { get; set; }
        public ISessionRepository SessionRepository { get; set; }
    }
}