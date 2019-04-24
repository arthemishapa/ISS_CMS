using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.CMS.Common.ViewModels
{
    public class UploadAbstractViewModel
    {
        public int ConferenceId { get; set; }

        [Required]
        [Display(Name = "Abstract title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Abstract content")]
        public string Content { get; set; }
    }
}