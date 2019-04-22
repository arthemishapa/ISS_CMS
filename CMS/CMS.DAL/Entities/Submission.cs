using System.Collections.Generic;
using CMS.CMS.Common.Enums;

namespace CMS.CMS.DAL.Entities
{
    public class Submission
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string Data { get; set; }
        public SubmissionType Type { get; set; }

        public User Author { get; set; }
        public IEnumerable<SubmissionReview> Reviews { get; set; }
    }
}