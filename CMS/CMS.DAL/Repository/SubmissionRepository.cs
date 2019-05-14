using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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

        public void UpdateSubmission(Submission submission)
        {
            
        }

        public void DeleteSubmission(int submissionId)
        {

        }

        public Submission GetSubmissionById(int submissionId)
        {
            return context.Submissions
                .Include(a => a.Author)
                .Include(c => c.Conference)
                .SingleOrDefault(s => s.Id == submissionId);
        }

        public IEnumerable<Submission> GetAll()
        {
            return context.Submissions
                .Include(a => a.Author)
                .Include(c => c.Conference)
                .ToList();
        }
    }
}