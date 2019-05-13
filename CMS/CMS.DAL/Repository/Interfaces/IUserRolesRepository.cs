using System.Collections.Generic;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IUserRolesRepository
    {
        void AddUserRole(UserRoles userRoles);
        IEnumerable<UserRoles> GetRolesForUser(string userId);
        IEnumerable<UserRoles> GetAll();
    }
}