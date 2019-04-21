using CMS.CMS.DAL.Entities;
using System.Collections.Generic;

namespace CMS.CMS.DAL.Repository
{
    public interface IConferenceRepository
    {
        void AddConference(Conference conference);
        void UpdateConference(Conference conference);
        void DeleteConference(int conferenceId);
        Conference GetConferenceById(int conferenceId);
        IEnumerable<Conference> GetAll();
    }
}