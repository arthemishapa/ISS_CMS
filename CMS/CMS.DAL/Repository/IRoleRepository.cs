using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IRoleRepository
    {
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        Role GetRoleById(int roleId);
    }
}