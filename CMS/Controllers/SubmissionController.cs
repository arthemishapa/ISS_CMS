using System;
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
        private string DocumentsDirectory = "~/Documents/";

        public SubmissionController(
            UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public FileStreamResult DownloadFile(string FileName)
        {
            var sDocument = Server.MapPath(DocumentsDirectory + FileName);

            return File(new FileStream(sDocument, FileMode.Open), "text/plain", FileName);
        }

        public ActionResult Submissions(int ConferenceID)
        {
            return View(unitOfWork.SubmissionRepository.GetAll().Where(s => s.ConferenceId == ConferenceID).ToList());
        }

        public ActionResult Details(int Id)
        {
            return View(GetSubmissionDetailsViewModel(Id));
        }

        [Authorize]
        public ActionResult Add(int id)
        {
            ViewBag.Title = "Add submission";

            return View("Submission", new SubmissionViewModel
            {
                ConferenceId = id,
                Sessions = GetSessionsSelectList(id),
                Action = "Add"
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(SubmissionViewModel model)
        {
            if (ModelState.IsValid && ((model.File != null) || !string.IsNullOrEmpty(model.Abstract)))
            {
                if (model.File != null && !TryUploadPaper(model.File))
                {
                    return SubmissionErrorView(model, "Please upload only files of type PDF/Word.", "Add");
                }

                var addedSubmission = unitOfWork.SubmissionRepository.AddSubmission(new Submission()
                {
                    ConferenceId = model.ConferenceId,
                    AuthorId = User.Identity.GetUserId(),
                    Title = model.Title,
                    Abstract = model.Abstract,
                    Filename = model.File?.FileName
                });

                return RedirectToAction("Details", "Submission", new { id = addedSubmission.Id });
            }

            return SubmissionErrorView(model, "Please add an abstract and/or a file.", "Add");
        }

        public ActionResult Edit(int id)
        {
            var submission = unitOfWork.SubmissionRepository.GetSubmissionById(id);

            if (User.Identity.GetUserId() != submission.AuthorId)
            {
                return RedirectToAction("Details", "Submission", new { id });
            }

            return View("Submission", new SubmissionViewModel
            {
                Id = submission.Id,
                ConferenceId = submission.ConferenceId,
                AuthorId = submission.AuthorId,
                Title = submission.Title,
                Abstract = submission.Abstract,
                FileName = submission.Filename,
                SelectedSession = "Muie PSD", // TODO
                Action = "Edit"
            });
        }

        [HttpPost]
        public ActionResult Edit(SubmissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    if (!TryUploadPaper(model.File))
                        return SubmissionErrorView(model, "Please upload only files of type PDF/Word.", "Edit");
                    if (model.FileName != null && model.File.FileName != model.FileName)
                        DeleteExistingFile(model.FileName);
                }

                unitOfWork.SubmissionRepository.UpdateSubmission(new Submission
                {
                    Id = model.Id,
                    Abstract = model.Abstract,
                    Filename = model.File != null ? model.File.FileName : model.FileName,
                });

                return RedirectToAction("Details", new { model.Id });
            }
            return View("Submission", model);
        }

        private ActionResult SubmissionErrorView(SubmissionViewModel model, string errorMessage, string action)
        {
            ViewBag.ErrorMessage = errorMessage;

            model.Sessions = GetSessionsSelectList(model.ConferenceId);
            model.Action = action;

            return View("Submission", model);
        }

        public ActionResult DecideToReview(int Id, bool review)
        {
            if (review)
            {
                unitOfWork.SubmissionReviewRepository.AddSubmissionReview(new SubmissionReview()
                {
                    ReviewerId = User.Identity.GetUserId(),
                    SubmissionId = Id
                });
            }
            return RedirectToAction("Submissions", new { ConferenceID = unitOfWork.SubmissionRepository.GetSubmissionById(Id).ConferenceId });
        }

        public ActionResult SubmitReview(int Id, string Review, string Recommendation)
        {
            unitOfWork.SubmissionReviewRepository.UpdateSubmissionReview(new SubmissionReview()
            {
                SubmissionId = Id,
                ReviewerId = User.Identity.GetUserId(),
                Review = (CMS.Common.Enums.Review)Enum.Parse(typeof(CMS.Common.Enums.Review), Review),
                Recommendation = Recommendation
            });
            return RedirectToAction("Submissions", new { ConferenceID = unitOfWork.SubmissionRepository.GetSubmissionById(Id).ConferenceId });
        }
        #region Helpers

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

        private void DeleteExistingFile(string filename)
        {
            var path = Path.Combine(Server.MapPath("~/Documents"), filename);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Documents"), filename));
        }

        private SubmissionDetailsViewModel GetSubmissionDetailsViewModel(int id)
        {
            var submission = unitOfWork.SubmissionRepository.GetSubmissionById(id);
            return new SubmissionDetailsViewModel()
            {
                Id = submission.Id,
                AuthorName = submission.Author.Name,
                ConferenceName = submission.Conference.Name,
                Title = submission.Title,
                Status = GetStatusMessage(submission),
                Abstract = submission.Abstract,
                FileName = submission.Filename,
                ConferenceId = submission.ConferenceId
            };
        }

        private string GetStatusMessage (Submission submission)
        {
            string status = "Unknown";
            DateTime today = DateTime.Now;

            if (today <= submission.Conference.AbstractPaperDeadline)
            {
                status = string.IsNullOrEmpty(submission.Abstract) ? "Abstract empty"
                : string.IsNullOrEmpty(submission.Filename) ? "File not uploaded"
                : "Ok";
            };

            return status;
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
        #endregion Helpers
    }
}