using CMS.CMS.DAL.Entities;
using System.Collections.Generic;

namespace CMS.CMS.DAL.Repository
{
    public interface IUserRolesRepository
    {
        void AddUser(UserRoles userRoles);
        void UpdateUserRoles(UserRoles userRoles);
        UserRoles GetUserRoles(string userId, int roleId);
        IEnumerable<UserRoles> GetAll();
    }
}