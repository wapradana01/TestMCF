using Azure;
using DataAccess.SharedObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Api.Apps.Middlewares
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        protected CurrentUserAccessor _currentUserAccessor;

        public AuthorizationFilter(CurrentUserAccessor currentUserAccessor)
        {
            _currentUserAccessor = currentUserAccessor;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (SkipAuthorization(context))
            {
                return;
            }

            try
            {
                if (context.HttpContext.User.Identity is ClaimsIdentity identity && identity.Claims != null && identity.Claims.Any())
                {
                    var sub = identity.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                    var sid = identity.Claims.FirstOrDefault(c => c.Type.Equals("sid"))?.Value;
                    
                    _currentUserAccessor.Id = !string.IsNullOrEmpty(sub) ? long.Parse(sub!) : _currentUserAccessor.Id;
                    _currentUserAccessor.UserName = sid ?? _currentUserAccessor.UserName;

                    return;
                }

                context.HttpContext.Response.StatusCode = 401;
                var response = new
                {
                    Message = "You are not authorized"
                };
                context.Result = new JsonResult(response);
            }
            catch (Exception ex)
            {
                context.HttpContext.Response.StatusCode = 401;
                return;
            }
        }

        private static bool SkipAuthorization(AuthorizationFilterContext context) => context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
    }
}
