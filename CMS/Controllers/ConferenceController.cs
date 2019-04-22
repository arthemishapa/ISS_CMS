using System;
using System.Web.Mvc;

using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL.Entities;
using CMS.CMS.DAL.Repository;

using Microsoft.AspNet.Identity;

namespace CMS.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository conferenceRepository;

        public ConferenceController(IConferenceRepository conferenceRepository)
        {
            this.conferenceRepository = conferenceRepository;
        }

        public ActionResult Details(int Id)
        {
            var conference = conferenceRepository.GetConferenceById(Id);
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
            var addedConference = conferenceRepository.AddConference(new Conference
            {
                Name = model.Name,
                ChairId = User.Identity.GetUserId(),
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                AbstractPaperDeadline = model.AbstractPaperDeadline,
                ProposalPaperDeadline = model.ProposalPaperDeadline,
                BiddingDeadline = model.BiddingDeadline
            });

            return RedirectToAction("Details", "Conference", new { addedConference.Id });
        }
    }
}