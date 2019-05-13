using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface ISubmissionRepository
    {
        Submission AddSubmission(Submission submission);
    }
}