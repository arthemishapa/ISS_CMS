using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IUserRolesRepository
    {
        void AddUser(User userRoles);
        void UpdateUserRoles(UserRoles userRoles);
        void DeleteUserRoles(UserRoles userRoles);
        UserRoles GetUserRoles(string userId, int roleId);
    }
}