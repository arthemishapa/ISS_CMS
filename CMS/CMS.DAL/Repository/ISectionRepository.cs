using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface ISectionRepository
    {
        void AddSection(Section section);
        void UpdateSection(Section section);
        void DeleteSection(int sectionId);
        Section GetSectionById(int sectionId);
    }
}