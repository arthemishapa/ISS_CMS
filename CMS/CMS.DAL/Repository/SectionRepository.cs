using CMS.CMS.DAL.DatabaseContext;

namespace CMS.CMS.DAL.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly CMSDbContext context;

        public SectionRepository(CMSDbContext context)
        {
            this.context = context;
        }
    }
}