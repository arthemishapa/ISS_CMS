using System.Collections.Generic;
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

        public void AddUser(User userRoles)
        {

        }

        public void UpdateUserRoles(UserRoles userRoles)
        {

        }

        public UserRoles GetUserRoles(string userId, int roleId)
        {
            return null;
        }

        public IEnumerable<UserRoles> GetAll()
        {
            return context.UserRoles.ToList();
        }
    }
}