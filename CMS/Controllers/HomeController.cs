using CMS.CMS.DAL.Repository;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConferenceRepository conferenceRepository;

        public HomeController(IConferenceRepository conferenceRepository)
        {
            this.conferenceRepository = conferenceRepository;
        }

        public ActionResult Index()
        {
            return View(conferenceRepository.GetAll());
        }
       
    }
}