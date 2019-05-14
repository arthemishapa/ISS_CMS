using System.Web.Mvc;

using CMS.CMS.DAL;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View(unitOfWork.ConferenceRepository.GetAll());
        }
       
    }
}