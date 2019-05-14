using CMS.CMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public IEnumerable<SubmissionReview> Reviews { get; set; }
    }
}