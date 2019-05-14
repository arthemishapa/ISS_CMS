using CMS.CMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly ISubmissionRepository submissionRepository;

        public SubmissionController(ISubmissionRepository submissionRepository)
        {
            this.submissionRepository = submissionRepository;
        }

        public ActionResult Submissions(int ConferenceID)
        {
            return View(submissionRepository.GetAll().Select(s => s.ConferenceId == ConferenceID));
        }

        public ActionResult Details(int Id)
        {
            return View();
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL;
using CMS.CMS.DAL.Entities;

using Microsoft.AspNet.Identity;

namespace CMS.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public SubmissionController(
            UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Add(int id)
        {
            return View(new AddSubmissionViewModel
            {
                ConferenceId = id,
                Sessions = GetSessionsSelectList(id)
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(AddSubmissionViewModel model)
        {
            if (ModelState.IsValid && ((model.File != null) || !string.IsNullOrEmpty(model.Abstract)))
            {
                if (model.File != null && !TryUploadPaper(model.File))
                {
                    return AddSubmissionErrorView(model, "Please upload only files of type PDF/Word.");
                }

                unitOfWork.SubmissionRepository.AddSubmission(new Submission()
                {
                    ConferenceId = model.ConferenceId,
                    AuthorId = User.Identity.GetUserId(),
                    Title = model.Title,
                    Abstract = model.Abstract,
                    Filename = model.File?.FileName
                });

                return RedirectToAction("Details", "Conference", new { id = model.ConferenceId });
            }

            return AddSubmissionErrorView(model, "Please add an abstract and/or a file.");
        }


        private bool TryUploadPaper(HttpPostedFileBase file)
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

        private IList<SelectListItem> GetSessionsSelectList(int id)
        {
            int index = 0;
            List<SelectListItem> sessions = new List<SelectListItem>();
            sessions.Insert(index, new SelectListItem()
            {
                Value = null,
                Text = "Select a session"
            });
            index++;
            foreach (Session session in unitOfWork.SessionRepository.GetAll().Where(s => s.ConferenceId == id))
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

        private ActionResult AddSubmissionErrorView(AddSubmissionViewModel model, string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            model.Sessions = GetSessionsSelectList(model.ConferenceId);
            return View(model);
        }
    }
}