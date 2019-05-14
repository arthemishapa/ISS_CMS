using System.Collections.Generic;
using System.Linq;

using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly CMSDbContext context;

        public RequestRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public Requests AddRequest(Requests request)
        {
            var addRequest = context.Requests.Add(request);
            context.SaveChanges();
            return addRequest;
        }

        public void DeleteRequest(int Id)
        {
            context.Requests.Remove(GetRequestById(Id));
            context.SaveChanges();
        }

        public IEnumerable<Requests> GetAll()
        {
            return context.Requests.ToList();
        }

        public Requests GetRequestById(int Id)
        {
            return context.Requests.SingleOrDefault(r => r.Id == Id);
        }
    }
}