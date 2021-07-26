using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.CustromRequirements;

namespace WebApplication1.Handlers
{
    public class CustomHandler1 : AuthorizationHandler<CustomRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequirement requirement)
        {
            if (context.User.Claims.Any(c => c.Type == "name" && c.Value == "Duc"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    public class CustomHandler2 : AuthorizationHandler<CustomRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequirement requirement)
        {
            if (context.User.Claims.Any(c => c.Type == "name" && c.Value == "Duc"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}