using CMS.CMS.DAL.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.CMS.Common.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAction : AuthorizeAttribute
    {
        public string RoleName { get; set; }

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

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            
            var Id = (httpContext.Request.RequestContext.RouteData.Values["id"] as string)
                     ??
                     (httpContext.Request["id"] as string);
            int conferenceId;
            int.TryParse(Id, out conferenceId);
            var userId = httpContext.User.Identity.Name;
            var role = RoleRepository.GetAll().SingleOrDefault(r => r.Name == RoleName);
            var privilege = UserRolesRepository.GetAll().SingleOrDefault(p => p.RoleId == role.Id
           && p.ConferenceId == conferenceId
           && p.UserId == userId);
            if (privilege != null)
                return true;
            return false;
        }
    }
}
