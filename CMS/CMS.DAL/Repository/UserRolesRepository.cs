using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly CMSDbContext context;

        public UserRolesRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public void AddUserRole(UserRoles userRoles)
        {
            context.UserRoles.Add(userRoles);
            context.SaveChanges();
        }

        public IEnumerable<UserRoles> GetAll()
        {
            return context.UserRoles;
        }

        public IEnumerable<UserRoles> GetRolesForUser(string userId)
        {
            return context.UserRoles
                .Include(ur => ur.Role)
                .Where(ur => ur.UserId == userId);
        }
    }
}