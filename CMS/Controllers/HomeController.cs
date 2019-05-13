using System.Web.Mvc;

using CMS.CMS.DAL.Repository;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConferenceRepository conferenceRepository;
        private readonly IUserRoleRepository userRolesRepository;
        private readonly IRoleRepository roleRepository;

        public HomeController(IConferenceRepository conferenceRepository, IUserRoleRepository userRolesRepository, IRoleRepository roleRepository)
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