using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IRoleRepository
    {
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int roleId);
        Role GetRoleById(int roleId);
    }
}