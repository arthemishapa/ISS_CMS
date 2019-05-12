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
        private readonly IConferenceRepository conferenceRepository;
        private readonly IUserRolesRepository userRolesRepository;

        public RequestController(IRequestRepository requestRepository,
            IConferenceRepository conferenceRepository,
            IUserRolesRepository userRolesRepository)
        {
            this.requestRepository = requestRepository;
            this.conferenceRepository = conferenceRepository;
            this.userRolesRepository = userRolesRepository;
        }

        public ActionResult Index()
        {
            return View(createViewModel());
        }

        public ActionResult ApproveRequest(int Id)
        {
            var request = requestRepository.GetRequestById(Id);

            return RedirectToAction("Index", "Request");
        }


        public ActionResult DeleteRequest(int Id)
        {
            requestRepository.DeleteRequest(Id);
            return RedirectToAction("Index", "Request");
        }

        private IEnumerable<RequestViewModel> createViewModel()
        {
            List<RequestViewModel> requests = new List<RequestViewModel>();

            foreach (Requests request in requestRepository.GetAll())
            {
                User Requester = requestRepository.GetAllUsers().SingleOrDefault(p => p.Id == request.UserRequesterId);
                User Chair = requestRepository.GetAllUsers().SingleOrDefault(p => p.Id == request.UserChairId);
                var conference = conferenceRepository.GetConferenceById(request.ConferenceId);
                string message = Requester.Name + " has asked for permission to be a " + request.Type +
                    " in your conference:" + conference.Name; 
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