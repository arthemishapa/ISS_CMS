using CMS.CMS.DAL.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMS.CMS.Common.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAction : AuthorizeAttribute
    {
        public string RoleName { get; set; }
        public bool ValidateRole { get; set; }

        private IUserRolesRepository UserRolesRepository
        {
            get
            {
                return DependencyResolver.Current.GetService<IUserRolesRepository>();
            }
        }

        private IRoleRepository RoleRepository
        {
            get
            {
                return DependencyResolver.Current.GetService<IRoleRepository>();
            }
        }

        private IUserRepository UserRepository
        {
            get
            {
                return DependencyResolver.Current.GetService<IUserRepository>();
            }
        }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            if(ValidateRole)
            {
                var Id = (httpContext.Request.RequestContext.RouteData.Values["id"] as string)
                     ??
                     (httpContext.Request["id"] as string);
                int conferenceId;
                int.TryParse(Id, out conferenceId);

                var userEmail = httpContext.User.Identity.Name;
                var user = UserRepository.GetUserByEmail(userEmail);
                var role = RoleRepository.GetAll().SingleOrDefault(r => r.Name == RoleName);
                var privilege = UserRolesRepository.GetAll().SingleOrDefault(p => p.RoleId == role.Id
               && p.ConferenceId == conferenceId
               && p.UserId == user.Id);
                if (privilege == null)
                    return false;
            }
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);

            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }
        }
    }
}
