using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL.Entities;
using CMS.CMS.DAL.Repository;

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
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddConferenceViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}