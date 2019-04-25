using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL.Entities;
using CMS.CMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository requestRepository;

        public RequestController(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public ActionResult Index()
        {
            return View(createViewModel());
        }

        private IEnumerable<RequestViewModel> createViewModel()
        {
            List<RequestViewModel> requests = new List<RequestViewModel>();

            foreach (Requests request in requestRepository.GetAll())
            {
                User Requester = requestRepository.GetAllUsers().SingleOrDefault(p => p.Id == request.UserRequesterId);
                User Chair = requestRepository.GetAllUsers().SingleOrDefault(p => p.Id == request.UserChairId);
                string message = Requester.Name + " has asked for permission to be a " + request.Type +
                    " in your conference with ID: " + request.ConferenceId; 
                requests.Add(new RequestViewModel()
                {
                    Id = request.Id,
                    RequestMessage = message
                });
            }

            return requests;
        }
    }
}