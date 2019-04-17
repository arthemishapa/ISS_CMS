using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly CMSDbContext context;

        public SectionRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public void AddSection(Section section)
        {

        }

        public void UpdateSection(Section section)
        {

        }

        public void DeleteSection(int sectionId)
        {

        }

        public Section GetSectionById(int sectionId)
        {
            return null;
        }
    }
}