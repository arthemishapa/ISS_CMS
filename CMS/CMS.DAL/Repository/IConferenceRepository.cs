using System.Collections.Generic;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IConferenceRepository
    {
        Conference AddConference(Conference conference);
        void UpdateConference(Conference conference);
        void DeleteConference(int conferenceId);
        Conference GetConferenceById(int conferenceId);
        IEnumerable<Conference> GetAll();
    }
}