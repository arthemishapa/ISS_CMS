using System.Collections.Generic;
using System.Linq;

using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CMSDbContext context;

        public UserRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.SingleOrDefault(u => u.Email == email);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }
    }
}