using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.WebAPI.src.Authorization
{
    public class AdminOrOwnerAccountHandler : AuthorizationHandler<AdminOrOwnerAccountRequirement, UserReadDTO>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminOrOwnerAccountRequirement requirement, UserReadDTO user)
        {
            var claims = context.User;
            var userRole = claims.FindFirst(c => c.Type == ClaimTypes.Role)!.Value;
            var userId = claims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            if (userId == user.Id.ToString() || userRole == Role.Admin.ToString())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    public class AdminOrOwnerAccountRequirement : IAuthorizationRequirement { }
}