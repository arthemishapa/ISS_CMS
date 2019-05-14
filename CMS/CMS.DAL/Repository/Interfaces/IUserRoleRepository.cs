using System.Collections.Generic;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IUserRoleRepository
    {
        void AddUserRole(UserRole userRole);
        //IEnumerable<UserRole> GetAll();
    }
}