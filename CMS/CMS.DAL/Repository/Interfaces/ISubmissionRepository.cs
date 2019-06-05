using System.Collections.Generic;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface ISubmissionRepository
    {
        Submission AddSubmission(Submission submission);
        void UpdateSubmission(Submission submission);
        void SetSubmissionSession(int submissionId, int sessionId);
        void DeleteSubmission(int submissionId);
        Submission GetSubmissionById(int submissionId);
        IEnumerable<Submission> GetAll();
    }
}