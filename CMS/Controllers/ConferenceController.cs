using System;
using System.Collections.Generic;
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
                SectionsList = new List<Section>
                {
                    new Section { Id = 1, Name = "S1" },
                    new Section { Id = 2, Name = "S2" }
                } // TODO: remove this
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddConferenceViewModel model)
        {
            conferenceRepository.AddConference(new Conference
            {
                Name = model.Name,
                ChairId = User.Identity.GetUserId(),
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                AbstractPaperDeadline = model.AbstractPaperDeadline,
                ProposalPaperDeadline = model.ProposalPaperDeadline,
                BiddingDeadline = model.BiddingDeadline
            });

            return RedirectToAction("Index", "Home"); // TODO: redirect to details page
        }
    }
}