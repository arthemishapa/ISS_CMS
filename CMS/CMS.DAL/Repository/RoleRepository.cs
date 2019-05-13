using System.Collections.Generic;
using System.Linq;

using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CMSDbContext context;

        public RoleRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return context.Roles.ToList();
        }
    }
}