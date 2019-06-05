using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.CMS.Common.ViewModels
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }

        [Display(Name = "Chair")]
        public string ChairId { get; set; }

        [Display(Name = "Session name")]
        public string Name { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}