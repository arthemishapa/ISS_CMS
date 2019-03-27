using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IConferenceRepository
    {
        void AddConference(Conference conference);
        void UpdateConference(Conference conference);
        void DeleteConference(Conference conference);
        Conference GetConferenceById(int conferenceId);
    }
}