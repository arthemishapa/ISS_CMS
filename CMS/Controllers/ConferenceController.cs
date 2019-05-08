using System;
using System.IO;
using System.Linq;
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
        private readonly ISubmissionRepository submissionRepository;
        private readonly IRequestRepository requestRepository;

        public ConferenceController(IConferenceRepository conferenceRepository, 
            ISubmissionRepository submissionRepository,
            IRequestRepository requestRepository)
        {
            this.conferenceRepository = conferenceRepository;
            this.submissionRepository = submissionRepository;
            this.requestRepository = requestRepository;
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

        public ActionResult JoinPC(int Id)
        {
            return PartialView("JoinPC", new JoinPCViewModel() { ConferenceId = Id });
        }

        public ActionResult FormUploadPaper(UploadPaperViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.ContentLength > 0)
                {
                    var allowedExtensions = new[] { "pdf", "docx" };

                    var fileName = Path.GetFileName(model.File.FileName);
                    var ext = Path.GetExtension(model.File.FileName).Replace(".", "");
                    if (allowedExtensions.Contains(ext))
                    {
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        var path = Path.Combine(Server.MapPath("~/Documents"), fileName);

                        submissionRepository.AddSubmission(new Submission() { ConferenceId = model.ConferenceId,
                            Data = fileName,
                            Title = model.Title,
                            Type = ext == "pdf" ? CMS.Common.Enums.SubmissionType.Pdf : CMS.Common.Enums.SubmissionType.Word,
                            AuthorId = System.Web.HttpContext.Current.User.Identity.GetUserId()
                        });

                        model.File.SaveAs(path);
                    }
                    else
                    {
                        ViewBag.message = "Please choose only pdf/word file";
                    }
                }
                else
                {
                    ViewBag.message = "Please upload a pdf/word file";
                }

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult FormJoinPC(JoinPCViewModel model)
        {
            if(ModelState.IsValid)
            {
                Conference conference = conferenceRepository.GetConferenceById(model.ConferenceId);

                requestRepository.AddRequest(
                    new Requests()
                    {
                        ConferenceId = conference.Id,
                        UserRequesterId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                        UserChairId = conference.ChairId,
                        Type = model.Role == "Chair" ? CMS.Common.Enums.RequestType.Chair :
                        model.Role == "Default" ? CMS.Common.Enums.RequestType.Default :
                        CMS.Common.Enums.RequestType.CoChair
                    });
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UploadPaper(int Id)
        {
            return PartialView("UploadPaper", new UploadPaperViewModel() { ConferenceId = Id });
        }

        public ActionResult FormUploadAbstract(UploadAbstractViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Content != null && model.Content.Length > 0)
                {
                    submissionRepository.AddSubmission(new Submission()
                    {
                        ConferenceId = model.ConferenceId,
                        Data = model.Content,
                        Title = model.Title,
                        AuthorId = System.Web.HttpContext.Current.User.Identity.GetUserId()
                    });
                }
                else
                {
                    ViewBag.message = "Please write something.";
                }

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UploadAbstract(int Id)
        {
            return PartialView("UploadAbstract", new UploadAbstractViewModel() { ConferenceId = Id });
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
            return View(model);
        }

        public ActionResult UpdateConference(int Id)
        {
            var conference = conferenceRepository.GetConferenceById(Id);
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

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateConference(UpdateConferenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedConference = conferenceRepository.GetConferenceById(model.Id);


                updatedConference.Name = model.Name;
                updatedConference.ChairId = User.Identity.GetUserId();
                updatedConference.StartDate = model.StartDate;
                updatedConference.EndDate = model.EndDate;
                updatedConference.AbstractPaperDeadline = model.AbstractPaperDeadline;
                updatedConference.ProposalPaperDeadline = model.ProposalPaperDeadline;
                updatedConference.BiddingDeadline = model.BiddingDeadline;
                conferenceRepository.UpdateConference(updatedConference);

                return RedirectToAction("Details", "Conference", new { updatedConference.Id });
            }
            return View(model);
        }
    }
}