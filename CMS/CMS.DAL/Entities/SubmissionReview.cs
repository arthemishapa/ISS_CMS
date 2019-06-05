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

        public string Recommendation { get; set; }

        public Review Review { get; set; }

        public Submission Submission { get; set; }
        public User Reviewer { get; set; }

        public int getSubmissionId() { return SubmissionId; }
        public void setSubmissionId(int id) { SubmissionId = id; }
        public string getReviewerId() { return ReviewerId; }
        public void setReviewerId(string id) { ReviewerId = id; }
        public string getRecommendation() { return Recommendation; }
        public void setRecommendation(string recommendation) { Recommendation = recommendation; }
    }
}