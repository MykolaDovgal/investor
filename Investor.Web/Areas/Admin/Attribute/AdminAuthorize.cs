using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Investor.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Investor.Web.Areas.Admin.Attribute
{
    public class RoleAuthorizeRequirement : IAuthorizationRequirement
    {
        public string Role { get; private set; }

        public RoleAuthorizeRequirement(string role)
        {
            Role = role;
        }
    }
    public class AdminAuthorize : AuthorizationHandler<RoleAuthorizeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            RoleAuthorizeRequirement requirement)
        {
            var controllerContext = context.Resource as AuthorizationFilterContext;
            var redirectResult = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                area = requirement.Role,
                controller = "Account",
                action = "Login"

            }));
            if (context.User?.Identity.IsAuthenticated ?? false)
            {
                if (context.User.HasClaim(c => c.Type == ClaimTypes.Role) && context.User.IsInRole(requirement.Role))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    if (controllerContext != null)
                    {
                        controllerContext.Result = redirectResult;
                    }
                    context.Succeed(requirement);
                }
            }
            else
            {
                if (controllerContext != null)
                {
                    controllerContext.Result = redirectResult;
                }
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
