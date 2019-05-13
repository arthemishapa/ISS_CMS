using System.Collections.Generic;

using CMS.CMS.Common.Enums;

namespace CMS.CMS.DAL.Entities
{
    public class Submission
    {
        public int Id { get; set; }

        public int ConferenceId { get; set; }
        public string AuthorId { get; set; }

        public string Title { get; set; }

        // TODO: uncomment
        public string Abstract { get; set; }
        public string Filename { get; set; }

        // TODO: delete
        public string Data { get; set; }
        public SubmissionType Type { get; set; }

        public User Author { get; set; }
        public IEnumerable<SubmissionReview> Reviews { get; set; }
    }
}