using System.Collections.Generic;

namespace CMS.CMS.DAL.Entities
{   // TODO Field for Grade
    public class Submission
    {
        public int Id { get; set; }

        public int ConferenceId { get; set; }
        public string AuthorId { get; set; }

        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Filename { get; set; }

        public User Author { get; set; }
        public Conference Conference { get; set; }

        public IEnumerable<SubmissionReview> Reviews { get; set; }
    }
}