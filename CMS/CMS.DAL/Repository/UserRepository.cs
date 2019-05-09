using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;
using System.Linq;

namespace CMS.CMS.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CMSDbContext context;

        public UserRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {

        }

        public void UpdateUser(User user)
        {

        }

        public void DeleteUser(string userId)
        {

        }

        public User GetUserById(string userId)
        {
            return null;
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.SingleOrDefault(u => u.Email == email);
        }
    }
}