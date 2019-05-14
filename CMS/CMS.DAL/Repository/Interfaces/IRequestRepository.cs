using System.Collections.Generic;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IRequestRepository
    {
        Request AddRequest(Request r);
        void DeleteRequest(int Id);
        Request GetRequestById(int Id);
        IEnumerable<Request> GetAll();
    }
}