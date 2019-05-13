using System.Collections.Generic;

using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly CMSDbContext context;

        public UserRoleRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public void AddUserRole(UserRole userRole)
        {
            context.UserRoles.Add(userRole);
            context.SaveChanges();
        }

        public IEnumerable<UserRole> GetAll()
        {
            return context.UserRoles;
        }
    }
}