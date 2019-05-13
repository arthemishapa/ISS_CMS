using System.Collections.Generic;

using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface IRequestRepository
    {
        Requests AddRequest(Requests r);
        void DeleteRequest(int Id);
        Requests GetRequestById(int Id);
        IEnumerable<Requests> GetAll();
    }
}