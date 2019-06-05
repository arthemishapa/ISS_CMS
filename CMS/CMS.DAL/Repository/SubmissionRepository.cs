using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public void UpdateSubmission(Submission submission)
        {
            var submissionToUpdate = GetSubmissionById(submission.Id);

            submissionToUpdate.Abstract = submission.Abstract;
            submissionToUpdate.Filename = submission.Filename;

            context.SaveChanges();
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

        public void SetSubmissionSession(int submissionId, int sessionId)
        {
            var submission = context.Submissions.SingleOrDefault(s => s.Id == submissionId);
            submission.SessionId = sessionId;
            context.SaveChanges();
        }
    }
}