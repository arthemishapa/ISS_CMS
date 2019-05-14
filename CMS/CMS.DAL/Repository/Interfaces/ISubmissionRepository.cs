using CMS.CMS.DAL.Entities;
using System.Collections.Generic;

namespace CMS.CMS.DAL.Repository
{
    public interface ISubmissionRepository
    {
        Submission AddSubmission(Submission submission);
        void UpdateSubmission(Submission submission);
        void DeleteSubmission(int submissionId);
        Submission GetSubmissionById(int submissionId);
        IEnumerable<Submission> GetAll();
    }
}