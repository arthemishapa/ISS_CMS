using System.Net;
using System.Web.Mvc;

using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL.Entities;
using CMS.CMS.DAL.Repository;

using Microsoft.AspNet.Identity;

namespace CMS.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly ISubmissionRepository submissionRepository;

        public SubmissionController(ISubmissionRepository submissionRepository)
        {
            this.submissionRepository = submissionRepository;
        }

        [Authorize]
        public ActionResult Add(int id)
        {
            return View(new AddSubmissionViewModel
            {
                ConferenceId = id
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(AddSubmissionViewModel model)
        {
            if (ModelState.IsValid && (!string.IsNullOrEmpty(model.Filename) || !string.IsNullOrEmpty(model.Abstract)))
            {
                submissionRepository.AddSubmission(new Submission()
                {
                    ConferenceId = model.ConferenceId,
                    AuthorId = User.Identity.GetUserId(),
                    Title = model.Title,
                    Abstract = model.Abstract,
                    Filename = model.Filename
                });
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}