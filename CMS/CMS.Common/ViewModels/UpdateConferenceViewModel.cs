using System;
using System.ComponentModel.DataAnnotations;

using CMS.CMS.Common.Validation;

namespace CMS.CMS.Common.ViewModels
{
    public class UpdateConferenceViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Conference name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Start date")]
        [UIHint("DateTime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End date")]
        [UIHint("DateTime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [ValidDate(StartDatePropertyName = "StartDate")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Abstract papers' deadline")]
        [UIHint("DateTime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [ValidDate(StartDatePropertyName = "StartDate", EndDatePropertyName = "BiddingDeadline")]
        public DateTime AbstractPaperDeadline { get; set; }

        [Required]
        [Display(Name = "Proposals deadline")]
        [UIHint("DateTime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [ValidDate(StartDatePropertyName = "StartDate", EndDatePropertyName = "BiddingDeadline")]
        public DateTime ProposalPaperDeadline { get; set; }

        [Required]
        [Display(Name = "Bidding deadline")]
        [UIHint("DateTime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [ValidDate(StartDatePropertyName = "StartDate", EndDatePropertyName = "EndDate")]
        public DateTime BiddingDeadline { get; set; }
    }
}