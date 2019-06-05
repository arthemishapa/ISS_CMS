using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL.Repository;

namespace CMS.CMS.Common.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAction : AuthorizeAttribute
    {
        public string RoleName { get; set; }
        public bool ValidateRole { get; set; }

        private IUserRoleRepository UserRolesRepository
        {
            get
            {
                return DependencyResolver.Current.GetService<IUserRoleRepository>();
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
                var Id = (httpContext.Request.Form["ConferenceId"] as string) ?? 
                    (httpContext.Request.RequestContext.RouteData.Values["ConferenceId"] as string);
               
                if (string.IsNullOrEmpty(Id))
                {
                    Id = (httpContext.Request.RequestContext.RouteData.Values["id"] as string)
                     ??
                     (httpContext.Request["id"] as string);
                }
                int.TryParse(Id, out  int conferenceId);

                var userEmail = httpContext.User.Identity.Name;
                var user = UserRepository.GetUserByEmail(userEmail);

                if (!string.IsNullOrEmpty(RoleName))
                {
                    var privilege = UserRolesRepository
                        .GetAll()
                        .SingleOrDefault(ur => ur.LocationId == conferenceId && ur.UserId == user.Id && RoleName.Contains(ur.Role.ToString()));
                    if (privilege == null)
                        return false;
                }
                else
                {
                    var privilege = UserRolesRepository
                        .GetAll()
                        .SingleOrDefault(ur => ur.LocationId == conferenceId && ur.UserId == user.Id);
                    if (privilege != null)
                        return false;
                }
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
