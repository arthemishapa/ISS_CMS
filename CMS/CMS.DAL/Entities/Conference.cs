using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.CMS.DAL.Entities
{
    public class Conference
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ChairId { get; set; }
        public User Chair { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AbstractPaperDeadline { get; set; }
        public DateTime ProposalPaperDeadline { get; set; }
        public DateTime BiddingDeadline { get; set; }

        public ICollection<Request> Requests { get; set; }

        public int getId() { return Id; }
        public void setId(int id) { Id = id; }
        public string getName() { return Name; }
        public void setName(string newName) { Name = newName; }
        public string getChairId() { return ChairId; }
        public void setChairId(string chairId) { ChairId = chairId; }
        public DateTime getStartDate() { return StartDate; }
        public void setStartDate(DateTime newDate) { StartDate = newDate; }

    }
}