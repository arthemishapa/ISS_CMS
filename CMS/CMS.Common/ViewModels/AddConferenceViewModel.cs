using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.CMS.Common.ViewModels
{
    public class AddConferenceViewModel
    {
        [Required]
        [Display(Name = "Conference name") ]
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
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Abstract papers' deadline")]
        [UIHint("DateTime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AbstractPaperDeadline { get; set; }

        [Required]
        [Display(Name = "Proposals deadline")]
        [UIHint("DateTime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProposalPaperDeadline { get; set; }

        [Required]
        [Display(Name = "Bidding deadline")]
        [UIHint("DateTime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BiddingDeadline { get; set; }
    }
}