using System.Collections.Generic;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
    }
}