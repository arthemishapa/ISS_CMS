using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL;
using CMS.CMS.DAL.Entities;

namespace CMS.Controllers
{
    public class RequestController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public RequestController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View(createViewModel());
        }

        public ActionResult ApproveRequest(int Id)
        {
            var request = unitOfWork.RequestRepository.GetRequestById(Id);

            return RedirectToAction("Index", "Request");
        }


        public ActionResult DeleteRequest(int Id)
        {
            unitOfWork.RequestRepository.DeleteRequest(Id);
            return RedirectToAction("Index", "Request");
        }

        private IEnumerable<RequestViewModel> createViewModel()
        {
            List<RequestViewModel> requests = new List<RequestViewModel>();

            foreach (Requests request in unitOfWork.RequestRepository.GetAll())
            {
                User Requester = unitOfWork.UserRepository.GetAll().SingleOrDefault(p => p.Id == request.UserRequesterId);
                User Chair = unitOfWork.UserRepository.GetAll().SingleOrDefault(p => p.Id == request.UserChairId);
                var conference = unitOfWork.ConferenceRepository.GetConferenceById(request.ConferenceId);
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