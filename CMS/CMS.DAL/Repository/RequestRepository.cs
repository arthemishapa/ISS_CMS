using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Requests> GetAll()
        {
            return context.Requests.ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public Requests GetRequestById(int Id)
        {
            return context.Requests.SingleOrDefault(r => r.Id == Id);
        }
    }
}