using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace CMS.CMS.Common.ViewModels
{
    public class AddSubmissionViewModel
    {
        public int ConferenceId { get; set; }
        public string AuthorId { get; set; }

        [Required]
        [Display(Name = "Paper title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Paper abstract")]
        public string Abstract { get; set; }

        [Display(Name = "File")]
        public HttpPostedFileBase File { get; set; }

        [Required]
        [Display(Name = "Session")]
        public string SelectedSession { get; set; }

        public IEnumerable<SelectListItem> Sessions { get; set; }
    }
}