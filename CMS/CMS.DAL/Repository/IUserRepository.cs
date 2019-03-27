using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User GetUserById(string userId);
    }
}