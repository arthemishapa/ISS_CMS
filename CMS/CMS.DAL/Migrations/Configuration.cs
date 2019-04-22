using System.Data.Entity.Migrations;
using CMS.CMS.DAL.DatabaseContext;

namespace CMS.CMS.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CMSDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
