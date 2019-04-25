using CMS.CMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.CMS.DAL.Repository
{
    public interface IRequestRepository
    {
        Requests AddRequest(Requests r);
        void DeleteRequest(int Id);
        Requests GetRequestById(int Id);
        IEnumerable<Requests> GetAll();
        IEnumerable<User> GetAllUsers();
    }
}