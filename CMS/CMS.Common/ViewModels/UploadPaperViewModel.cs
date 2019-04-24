using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.CMS.Common.ViewModels
{
    public class UploadPaperViewModel
    {
        public int ConferenceId { get; set; }

        [Required]
        [Display(Name = "Paper title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "File")]
        public HttpPostedFileBase File { get; set; }
    }
}