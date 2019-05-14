using CMS.CMS.DAL.Repository;

namespace CMS.CMS.DAL
{
    public class UnitOfWork
    {
        public IConferenceRepository ConferenceRepository { get; }
        public IRequestRepository RequestRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public ISessionRepository SessionRepository { get; }
        public IUserRepository UserRepository { get; set; }
        public ISubmissionRepository SubmissionRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }

        public UnitOfWork(
            IConferenceRepository conferenceRepository,
            IRequestRepository requestRepository,
            IUserRoleRepository userRoleRepository,
            ISessionRepository sessionRepository,
            IUserRepository userRepository,
            ISubmissionRepository submissionRepository,
            IRoleRepository roleRepository)
        {
            ConferenceRepository = conferenceRepository;
            RequestRepository = requestRepository;
            UserRoleRepository = userRoleRepository;
            SessionRepository = sessionRepository;
            UserRepository = userRepository;
            SubmissionRepository = submissionRepository;
            RoleRepository = roleRepository;
        }
    }
}