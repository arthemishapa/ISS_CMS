using CMS.CMS.DAL.Repository;
using System.Web.Mvc;
using CMS.CMS.Common.Validation;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConferenceRepository conferenceRepository;
        private readonly IUserRolesRepository userRolesRepository;
        private readonly IRoleRepository roleRepository;

        public HomeController(IConferenceRepository conferenceRepository, IUserRolesRepository userRolesRepository, IRoleRepository roleRepository)
        {
            this.conferenceRepository = conferenceRepository;
            this.userRolesRepository = userRolesRepository;
            this.roleRepository = roleRepository;
        }
        public ActionResult Index()
        {
            return View(conferenceRepository.GetAll());
        }
       
    }
}