using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.CMS.Common.Validation;
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
            var conference = unitOfWork.ConferenceRepository.GetConferenceById(ConferenceID);
            Session["status"] = conference.BiddingDeadline >= DateTime.Now 
                && conference.AbstractPaperDeadline < DateTime.Now ? "Bidding" : 
                conference.AbstractPaperDeadline >= DateTime.Now ? "Call for papers" : "Review";

            return View(unitOfWork.SubmissionRepository.GetAll().Where(s => s.ConferenceId == ConferenceID).ToList());
        }

        public ActionResult Details(int Id)
        {
            Session["reviewed"] = unitOfWork.SubmissionReviewRepository.GetAll().Where(s => s.SubmissionId == Id
                && s.ReviewerId == User.Identity.GetUserId()
                && s.Review != CMS.Common.Enums.Review.None).Count() >= 1 ? "true" : "false";
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
        [AuthorizeAction(RoleName = "Author", ValidateRole = true)]
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
                    Filename = model.File?.FileName,
                    Mark = -1
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
        [AuthorizeAction(RoleName = "Author", ValidateRole = true)]
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
                    Mark = -1
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

        [AuthorizeAction(RoleName = "PCMember", ValidateRole = true)]
        public ActionResult DecideToReview(int Id, int SubmissionId, bool review)
        {
            if (review)
            {
                unitOfWork.SubmissionReviewRepository.AddSubmissionReview(new SubmissionReview()
                {
                    ReviewerId = User.Identity.GetUserId(),
                    SubmissionId = SubmissionId,
                    Review = CMS.Common.Enums.Review.None
                });
            }
            return RedirectToAction("Submissions", new { ConferenceID = Id });
        }

        [AuthorizeAction(RoleName = "PCMember", ValidateRole = true)]
        public ActionResult SubmitReview(int ConferenceId, int Id, string Review, string Recommendation)
        {
            if (unitOfWork.SubmissionReviewRepository.GetAll().Where(s => s.SubmissionId == Id
             && s.ReviewerId == User.Identity.GetUserId()).Count() >= 1)
            {
                unitOfWork.SubmissionReviewRepository.UpdateSubmissionReview(new SubmissionReview()
                {
                    SubmissionId = Id,
                    ReviewerId = User.Identity.GetUserId(),
                    Review = (CMS.Common.Enums.Review)Enum.Parse(typeof(CMS.Common.Enums.Review), Review),
                    Recommendation = Recommendation
                });
                CheckAndGiveFinalGrade(Id);
                Session["reviewed"] = "true";
            }
            return RedirectToAction("Submissions", new { ConferenceID = ConferenceId });
        }
        #region Helpers

        private void CheckAndGiveFinalGrade(int submissionId)
        {
            if(unitOfWork.SubmissionReviewRepository.GetAll().Count(s => s.SubmissionId == submissionId && s.Review == CMS.Common.Enums.Review.None) == 0)
            {
                int mark = unitOfWork.SubmissionReviewRepository.GetAll().Where(s => s.SubmissionId == submissionId)
                    .Sum(s => (int)s.Review);

                var submission = unitOfWork.SubmissionRepository.GetSubmissionById(submissionId);
                unitOfWork.SubmissionRepository.UpdateSubmission(new Submission
                {
                    Id = submissionId,
                    Abstract = submission.Abstract,
                    Filename = submission.Filename,
                    Mark = mark
                });
            }
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

        private void DeleteExistingFile(string filename)
        {
            var path = Path.Combine(Server.MapPath("~/Documents"), filename);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Documents"), filename));
        }

        private SubmissionDetailsViewModel GetSubmissionDetailsViewModel(int id)
        {
            var submission = unitOfWork.SubmissionRepository.GetSubmissionById(id);
            var reviews = unitOfWork.SubmissionReviewRepository.GetAll().Where(s => s.SubmissionId == id);
            return new SubmissionDetailsViewModel()
            {
                Id = submission.Id,
                AuthorName = submission.Author.Name,
                ConferenceName = submission.Conference.Name,
                Title = submission.Title,
                Status = GetStatusMessage(submission),
                Abstract = submission.Abstract,
                FileName = submission.Filename,
                ConferenceId = submission.ConferenceId,
                Reviews = reviews
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