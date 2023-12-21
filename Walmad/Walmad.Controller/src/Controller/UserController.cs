using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

[ApiController]
[Route("api/v1/[controller]s")]
public class UserController : BaseController<User, UserReadDTO, UserCreateDTO, UserUpdateDTO, IUserService>
{
    public UserController(IUserService service) : base(service)
    {
    }

    // [Authorize(Policy = "SuperAdmin")]
    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public override ActionResult<IEnumerable<UserReadDTO>> GetAll([FromQuery] GetAllParams options)
    {
        return Ok(_service.GetAll(options));
    }
}
