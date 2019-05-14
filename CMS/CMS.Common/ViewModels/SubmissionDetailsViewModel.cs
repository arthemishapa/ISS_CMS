using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.Common.ViewModels
{
    public class SubmissionDetailsViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        [Display(Name = "Author name")]
        public string AuthorName { get; set; }
        [Display(Name = "Conference name")]
        public string ConferenceName { get; set; }
        [Display(Name = "Paper title")]
        public string Title { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Abstract")]
        public string Abstract { get; set; }
        public int ConferenceId { get; set; }
        public IEnumerable<SubmissionReview> Reviews { get; set; }
    }
}