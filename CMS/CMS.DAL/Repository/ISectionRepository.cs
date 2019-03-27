using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface ISectionRepository
    {
        void AddSection(Section section);
        void UpdateSection(Section section);
        void DeleteSection(Section section);
        Section GetSectionById(int sectionId);
    }
}