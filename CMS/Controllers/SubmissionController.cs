using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
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
        private readonly ISessionRepository sessionRepository;

        public SubmissionController(ISubmissionRepository submissionRepository, ISessionRepository sessionRepository)
        {
            this.submissionRepository = submissionRepository;
            this.sessionRepository = sessionRepository;
        }

        [Authorize]
        public ActionResult Add(int id)
        {
            int index = 0;
            List<SelectListItem> sessions = new List<SelectListItem>();
            sessions.Insert(index, new SelectListItem()
            {
                Value = null,
                Text = "Select a session"
            });
            index++;
            foreach (Session session in sessionRepository.GetAll().Where(s => s.ConferenceId == id))
            {
                sessions.Insert(index, new SelectListItem()
                {
                    Value = index.ToString(),
                    Text = session.Name
                });
                index++;
            }

            return View(new AddSubmissionViewModel
            {
                ConferenceId = id,
                Sessions = sessions
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(AddSubmissionViewModel model)
        {
            if (ModelState.IsValid && (!string.IsNullOrEmpty(model.File.FileName) || !string.IsNullOrEmpty(model.Abstract)))
            {
                if (!string.IsNullOrEmpty(model.File.FileName) && !UploadPaper(model.File))
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Please upload a pdf/word file.");

                submissionRepository.AddSubmission(new Submission()
                {
                    ConferenceId = model.ConferenceId,
                    AuthorId = User.Identity.GetUserId(),
                    Title = model.Title,
                    Abstract = model.Abstract,
                    Filename = model.File.FileName
                });
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Please add an abstract and/or a file.");
        }

        private bool UploadPaper(HttpPostedFileBase file)
        {
            var allowedExtensions = new[] { "pdf", "docx" };

            var fileName = Path.GetFileName(file.FileName);
            var ext = Path.GetExtension(file.FileName).Replace(".", "");
            if (allowedExtensions.Contains(ext))
            {
                string name = Path.GetFileNameWithoutExtension(fileName);
                var path = Path.Combine(Server.MapPath("~/Documents"), fileName);

                file.SaveAs(path);
                return true;
            }

            return false;
        }
    }
}