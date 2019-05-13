using CMS.CMS.DAL.DatabaseContext;

namespace CMS.CMS.DAL.Repository
{
    public class SubmissionReviewRepository : ISubmissionReviewRepository
    {
        private readonly CMSDbContext context;

        public SubmissionReviewRepository(CMSDbContext context)
        {
            this.context = context;
        }
    }
}