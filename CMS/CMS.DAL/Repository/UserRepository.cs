using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public void AddUser(User user)
        {

        }

        public void UpdateUser(User user)
        {

        }

        public void DeleteUser(User user)
        {

        }

        public User GetUserById(string userId)
        {
            return null;
        }
    }
}