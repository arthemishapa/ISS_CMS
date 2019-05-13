using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            return View(new AddSubmissionViewModel
            {
                ConferenceId = id,
                Sessions = GetSessions(id)
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(AddSubmissionViewModel model)
        {
            if (ModelState.IsValid && ((model.File != null) || !string.IsNullOrEmpty(model.Abstract)))
            {
                if (model.File != null && !UploadPaper(model.File))
                {
                    ViewBag.ValidationMessage = "Please upload only files of type PDF/Word.";
                    model.Sessions = GetSessions(model.ConferenceId);
                    return View(model);
                }

                submissionRepository.AddSubmission(new Submission()
                {
                    ConferenceId = model.ConferenceId,
                    AuthorId = User.Identity.GetUserId(),
                    Title = model.Title,
                    Abstract = model.Abstract,
                    Filename = model.File.FileName
                });

                return RedirectToAction("Details", "Conference", new { id = model.ConferenceId });
            }

            ViewBag.ValidationMessage = "Please add an abstract and/or a file.";
            model.Sessions = GetSessions(model.ConferenceId);
            return View(model);
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

        private IEnumerable<SelectListItem> GetSessions(int id)
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

            return sessions;
        }
    }
}