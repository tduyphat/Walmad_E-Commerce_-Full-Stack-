using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    private IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    // 2 step verification: login to get token -> send token to get profile
    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] LoginDTO loginDto)
    {
        return _authenticationService.Login(loginDto);
    }
}