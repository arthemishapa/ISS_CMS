using System;

namespace CMS.CMS.DAL.Entities
{
    public class Conference
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AbstractPaperDeadline { get; set; }
        public DateTime ProposalPaperDeadline { get; set; }
        public DateTime BiddingDeadline { get; set; }
    }
}