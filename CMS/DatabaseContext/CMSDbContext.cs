using System.Data.Entity;
using CMS.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CMS.DatabaseContext
{
    public class CMSDbContext : IdentityDbContext<User>
    {
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