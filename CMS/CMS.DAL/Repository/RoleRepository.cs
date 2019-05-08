using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.CMS.DAL.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CMSDbContext context;

        public RoleRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public void AddRole(Role role)
        {

        }

        public void UpdateRole(Role role)
        {

        }

        public void DeleteRole(int roleId)
        {

        }

        public Role GetRoleById(int roleId)
        {
            return null;
        }
        public IEnumerable<Role> GetAll()
        {
            return context.Roles.ToList();
        }
    }
}