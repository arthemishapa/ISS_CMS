using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CMS.CMS.Common.Enums;

namespace CMS.CMS.DAL.Entities
{
    public class SubmissionReview
    {
        [Key]
        [Column(Order = 1)]
        public int SubmissionId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string ReviewerId { get; set; }

        public Review Review { get; set; }

        public Submission Submission { get; set; }
        public User Reviewer { get; set; }
    }
}