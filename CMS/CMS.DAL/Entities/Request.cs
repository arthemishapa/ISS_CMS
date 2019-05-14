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
    }
}