using CMS.CMS.Common.Enums;
using System.Collections.Generic;
namespace CMS.CMS.DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public string UserRequesterId { get; set; }
        public int ConferenceId { get; set; }
        public int? LocationId { get; set; }
        public Role Type { get; set; }
        public User UserRequester { get; set; }
        public Conference Conference { get; set; }

        public int getId() { return Id; }
        public void setId(int id) { Id = id; }
        public string getUserRequesterId() { return UserRequesterId; }
        public void setUserRequesterId(string id) { UserRequesterId = id; }
        public int getConferenceId() { return ConferenceId; }
        public void setConferenceId(int id) { ConferenceId = id; }
        public int? getLocationId() { return LocationId; }
        public void setLocationId(int? id) { LocationId = id; }
    }
}