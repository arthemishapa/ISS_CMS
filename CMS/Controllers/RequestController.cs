using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL;
using CMS.CMS.DAL.Entities;
using Microsoft.AspNet.Identity;

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
            unitOfWork.UserRoleRepository.AddUserRole(new UserRole()
            {
                UserId = request.UserRequesterId,
                LocationId = request.ConferenceId,
                Role = request.Type
            });
            unitOfWork.RequestRepository.DeleteRequest(Id);

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
            string loggedUserId = User.Identity.GetUserId();
            foreach (Request request in unitOfWork.RequestRepository.GetAll().Where(r => r.UserRequesterId != loggedUserId))
            {
                if (unitOfWork.UserRoleRepository.GetAll()
                    .Count(u => u.UserId == loggedUserId 
                            && u.LocationId == request.ConferenceId
                            && ((int)u.Role == 1 || (int)u.Role == 2)) > 0)
                {
                    string message = request.UserRequester.Name + " has asked for permission to be a " + request.Type +
                        " in your conference:" + request.Conference.Name;
                    requests.Add(new RequestViewModel()
                    {
                        Id = request.Id,
                        RequestMessage = message
                    });
                }
            }

            return requests;
        }
    }
}