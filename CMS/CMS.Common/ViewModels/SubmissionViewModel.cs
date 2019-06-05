using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CMS.CMS.Common.ViewModels
{
    public class SubmissionViewModel
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public string AuthorId { get; set; }

        [Required]
        [Display(Name = "Paper title")]
        public string Title { get; set; }

        [Display(Name = "Paper abstract")]
        public string Abstract { get; set; }

        [Display(Name = "File")]
        public HttpPostedFileBase File { get; set; }

        [Display(Name = "Paper filename")]
        public string FileName { get; set; }

        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [Display(Name = "Session")]
        public int SessionId { get; set; }

        public string Action { get; set; }
        public IEnumerable<SessionViewModel> Sessions { get; set; }
    }
}