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

        public Submission AddSubmission(Submission submission)
        {
            var addedSubmission = context.Submissions.Add(submission);
            context.SaveChanges();
            return addedSubmission;
        }
    }
}