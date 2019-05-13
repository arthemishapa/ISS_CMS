using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.CMS.Common.ViewModels
{
    public class AddSubmissionViewModel
    {
        public int ConferenceId { get; set; }
        public string AuthorId { get; set; }

        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Filename { get; set; }
    }
}