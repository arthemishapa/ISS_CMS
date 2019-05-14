using System.Data.Entity;
using CMS.CMS.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CMS.CMS.DAL.DatabaseContext
{
    public class CMSDbContext : IdentityDbContext<User>
    {
        public DbSet<Conference> Conferences { get; set; }
        public new DbSet<Role> Roles { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Submission> Submissions { get; set; }
       // public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<SubmissionReview> SubmissionReviews { get; set; }
        public DbSet<Requests> Requests { get; set; }

        public CMSDbContext()
            : base("CMSDatabase", throwIfV1Schema: false)
        {
        }

        public static CMSDbContext Create()
        {
            return new CMSDbContext();
        }
    }
}