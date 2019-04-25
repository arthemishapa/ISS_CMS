using CMS.CMS.Common.Enums;
using System.Collections.Generic;
namespace CMS.CMS.DAL.Entities
{
    public class Requests
    {
        public int Id { get; set; }
        public string UserRequesterId { get; set; }
        public string UserChairId { get; set; }
        public List<string> UserCoChairId { get; set; }
        public int ConferenceId { get; set; }
        public int SessionId { get; set; }
        public RequestType Type { get; set; }
    }
}