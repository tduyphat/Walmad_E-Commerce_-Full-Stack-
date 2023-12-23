// using System.Data.Common;
// using System.Security.Claims;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.EntityFrameworkCore;
// using Walmad.Core.src.Entity;
// using Walmad.WebAPI.src.Database;

// namespace Walmad.WebAPI.src.Authorization;
// public class CheckAddressRequirement : IAuthorizationRequirement
// {
//     public int MaxLength { get; set; }
//     public CheckAddressRequirement(int maxLength)
//     {
//         MaxLength = maxLength;
//     }
// }

// public class CheckAddressHandler : AuthorizationHandler<CheckAddressRequirement>
// {
//     private readonly DbSet<User> _users;

//     public CheckAddressHandler(DatabaseContext db)
//     {
//         _users = db.Users;
//     }
//     protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CheckAddressRequirement requirement)
//     {
//         var claims = context.User;
//         var userId = claims.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier)!.Value;
//         var user = _users.Find(userId);
//         if (user.Addresses.Count() < requirement.MaxLength)
//         {
//             context.Succeed(requirement);
//         }
//         return Task.CompletedTask;
//     }
// }