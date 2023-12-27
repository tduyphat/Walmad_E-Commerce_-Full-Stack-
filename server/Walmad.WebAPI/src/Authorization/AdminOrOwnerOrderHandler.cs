using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.WebAPI.src.Authorization
{
    public class AdminOrOwnerOrderHandler : AuthorizationHandler<AdminOrOwnerOrderRequirement, OrderReadDTO>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminOrOwnerOrderRequirement requirement, OrderReadDTO order)
        {
            var claims = context.User;
            var userRole = claims.FindFirst(c => c.Type == ClaimTypes.Role)!.Value;
            var userId = claims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            if (userId == order.User.Id.ToString() || userRole == Role.Admin.ToString())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    public class AdminOrOwnerOrderRequirement : IAuthorizationRequirement { }
}

