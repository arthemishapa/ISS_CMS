using System.Collections.Generic;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IRoleRepository
    {
        Role GetRoleByName(string name);
        IEnumerable<Role> GetAll();
    }
}