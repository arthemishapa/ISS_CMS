using CMS.CMS.DAL.Repository;
using System.Web.Mvc;
using CMS.CMS.Common.Validation;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConferenceRepository conferenceRepository;

        public HomeController(IConferenceRepository conferenceRepository)
        {
            this.conferenceRepository = conferenceRepository;
        }
        [AuthorizeAction]
        public ActionResult Index()
        {
            return View(conferenceRepository.GetAll());
        }
       
    }
}