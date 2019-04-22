using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       
    }
}