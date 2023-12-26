using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    // 2 step verification: login to get token -> send token to get profile
    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] Credentials credentials)
    {
        return _authService.Login(credentials);
    }

    [Authorize]
    [HttpGet("profile")]
    public ActionResult<UserReadDTO> GetCurrentProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return Ok(_authService.GetCurrentProfile(Guid.Parse(userId)));
    }
}