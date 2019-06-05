using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using CMS.CMS.Common.Enums;
using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL;
using CMS.CMS.DAL.Entities;

namespace CMS.Controllers
{
    public class SessionController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public SessionController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult AddSession(int conferenceId)
        {
            IEnumerable<string> conferenceComitee = unitOfWork.UserRoleRepository.GetAll().Where(ur => ur.LocationId == conferenceId && (ur.Role == Role.Chair || ur.Role == Role.CoChair || ur.Role == Role.PCMember)).Select(ur => ur.UserId);
            SessionViewModel model = new SessionViewModel
            {
                Users = unitOfWork.UserRepository.GetAll().Where(u => conferenceComitee.Contains(u.Id)).Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Name
                })
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddSession(SessionViewModel model)
        {
            if (ModelState.IsValid && !unitOfWork.SessionRepository.GetAll().Any(s => s.ConferenceId == model.ConferenceId && s.Name == model.Name))
            {
                var addedSession = unitOfWork.SessionRepository.AddSession(new Session
                {
                    ConferenceId = model.ConferenceId,
                    ChairId = model.ChairId,
                    Name = model.Name
                });

                unitOfWork.UserRoleRepository.AddUserRole(new UserRole
                {
                    UserId = model.ChairId,
                    LocationId = addedSession.Id,
                    Role = Role.ChairForSession
                });

                return RedirectToAction("Details", "Conference", new { id = model.ConferenceId });
            }

            ViewBag.ErrorMessage = $"There already exists a session {model.Name} for this conference.";
            return AddSession(model.ConferenceId);
        }
    }
}