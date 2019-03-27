using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public void AddRole(Role role)
        {

        }

        public void UpdateRole(Role role)
        {

        }

        public void DeleteRole(Role role)
        {

        }

        public Role GetRoleById(int roleId)
        {
            return null;
        }
    }
}