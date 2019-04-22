using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly CMSDbContext context;

        public SubmissionRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public void AddSubmission(Submission submission)
        {

        }

        public void UpdateSubmission(Submission submission)
        {

        }

        public void DeleteSubmission(int submissionId)
        {

        }

        public Submission GetSubmissionById(int submissionId)
        {
            return null;
        }
    }
}