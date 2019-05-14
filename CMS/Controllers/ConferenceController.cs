using System;
using System.Web.Mvc;

using CMS.CMS.Common.Validation;
using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL;
using CMS.CMS.DAL.Entities;

using Microsoft.AspNet.Identity;

namespace CMS.Controllers
{
    [AuthorizeAction(ValidateRole = false)]
    public class ConferenceController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public ConferenceController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public ActionResult Details(int Id)
        {
            var conference = unitOfWork.ConferenceRepository.GetConferenceById(Id);
            return View(new ConferenceDetailsViewModel() {
                Id = conference.Id,
                Name = conference.Name,
                ProposalPaperDeadline = conference.ProposalPaperDeadline,
                AbstractPaperDeadline = conference.AbstractPaperDeadline,
                BiddingDeadline = conference.BiddingDeadline,
                StartDate = conference.StartDate,
                EndDate = conference.EndDate
            });
        }

        [HttpPost]
        public void AddSessions(string[] sessions)
        {
            if (sessions.Length > 1)
            {
                int.TryParse(sessions[0], out int conferenceID);
                string UserID = System.Web.HttpContext.Current.User.Identity.GetUserId();
                for (int i = 1; i < sessions.Length; i++)
                {
                    unitOfWork.SessionRepository.AddSession(new Session() {
                        ChairId = UserID,
                        ConferenceId = conferenceID,
                        Name = sessions[i]
                    });
                }
            }
        }

        public ActionResult JoinConference(int Id)
        {
            return PartialView("JoinConference", new JoinConferenceViewModel() { ConferenceId = Id });
        }

        // TODO: authorize only for users not having any role within the conference
        //[AuthorizeAction(ValidateRole = true)]
        public ActionResult FormJoinConference(JoinConferenceViewModel model)
        {
            if(ModelState.IsValid)
            {
                Conference conference = unitOfWork.ConferenceRepository.GetConferenceById(model.ConferenceId);

                unitOfWork.RequestRepository.AddRequest(
                    new Request()
                    {
                        ConferenceId = conference.Id,
                        UserRequesterId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                        Type = model.Role == "Author" ? CMS.Common.Enums.Role.Author :
                        model.Role == "PC Member" ? CMS.Common.Enums.Role.PCMember :
                        CMS.Common.Enums.Role.CoChair
                    });
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Add()
        {
            var viewModel = new AddConferenceViewModel
            {
                StartDate = DateTime.Now.Date.AddDays(1),
                EndDate = DateTime.Now.Date.AddDays(1),
                AbstractPaperDeadline = DateTime.Now.Date.AddDays(1),
                ProposalPaperDeadline = DateTime.Now.Date.AddDays(1),
                BiddingDeadline = DateTime.Now.Date.AddDays(1),
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddConferenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var addedConference = unitOfWork.ConferenceRepository.AddConference(new Conference
                {
                    Name = model.Name,
                    ChairId = User.Identity.GetUserId(),
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    AbstractPaperDeadline = model.AbstractPaperDeadline,
                    ProposalPaperDeadline = model.ProposalPaperDeadline,
                    BiddingDeadline = model.BiddingDeadline
                });
                
                unitOfWork.UserRoleRepository.AddUserRole(new UserRole
                {
                    LocationId = addedConference.Id,
                    UserId = User.Identity.GetUserId(),
                    Role = CMS.Common.Enums.Role.Chair
                });

                return RedirectToAction("Details", "Conference", new { addedConference.Id });
            }
            return View(model);
        }

        // TODO: breaks with two "AuthorizeAction" attributes
        [AuthorizeAction(RoleName = "Chair, CoChair", ValidateRole = true)]
        //[AuthorizeAction(RoleName = "CoChair", ValidateRole = true)]
        public ActionResult UpdateConference(int Id)
        {
            var conference = unitOfWork.ConferenceRepository.GetConferenceById(Id);
            return View(new UpdateConferenceViewModel()
            {
                Id = conference.Id,
                Name = conference.Name,
                ProposalPaperDeadline = conference.ProposalPaperDeadline,
                AbstractPaperDeadline = conference.AbstractPaperDeadline,
                BiddingDeadline = conference.BiddingDeadline,
                StartDate = conference.StartDate,
                EndDate = conference.EndDate
            });
        }

        // TODO: breaks with two "AuthorizeAction" attributes
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAction(RoleName = "Chair, CoChair", ValidateRole = true)]
        //[AuthorizeAction(RoleName = "CoChair", ValidateRole = true)]
        public ActionResult UpdateConference(UpdateConferenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ConferenceRepository.UpdateConference(new Conference
                {
                    Id = model.Id,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    AbstractPaperDeadline = model.AbstractPaperDeadline,
                    ProposalPaperDeadline = model.ProposalPaperDeadline,
                    BiddingDeadline = model.BiddingDeadline,
                });

                return RedirectToAction("Details", "Conference", new { model.Id });
            }
            return View(model);
        }
    }
}