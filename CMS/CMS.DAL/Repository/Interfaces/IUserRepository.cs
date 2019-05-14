using System.Collections.Generic;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        IEnumerable<User> GetAll();
    }
}