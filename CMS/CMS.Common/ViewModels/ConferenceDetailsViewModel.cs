using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.CMS.Common.ViewModels
{
    public class ConferenceDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Conference name")]
        public string Name { get; set; }

        public string ChairId { get; set; }

        [Display(Name = "Conference start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Conference end date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Submit abstract deadline")]
        public DateTime AbstractPaperDeadline { get; set; }
        [Display(Name = "Submit paper deadline")]
        public DateTime ProposalPaperDeadline { get; set; }
        [Display(Name = "Bidding deadline")]
        public DateTime BiddingDeadline { get; set; }
    }
}