using System.Collections.Generic;
using System.Linq;

using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;
using System.Data.Entity;

namespace CMS.CMS.DAL.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly CMSDbContext context;

        public RequestRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public Request AddRequest(Request request)
        {
            var addRequest = context.Request.Add(request);
            context.SaveChanges();
            return addRequest;
        }

        public void DeleteRequest(int Id)
        {
            context.Request.Remove(GetRequestById(Id));
            context.SaveChanges();
        }

        public IEnumerable<Request> GetAll()
        {
            return context.Request
                    .Include(a => a.UserRequester)
                    .Include(a => a.Conference)
                    .ToList();
        }

        public Request GetRequestById(int Id)
        {
            return context.Request
                .Include(a => a.UserRequester)
                .Include(a => a.Conference)
                .SingleOrDefault(r => r.Id == Id);
        }
    }
}