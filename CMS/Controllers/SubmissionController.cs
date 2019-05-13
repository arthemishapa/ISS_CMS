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