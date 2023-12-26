using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

[ApiController]
[Route("api/v1/[controller]s")]
public class UserController : BaseController<User, UserReadDTO, UserCreateDTO, UserUpdateDTO, IUserService>
{
    private IAuthorizationService _authorizationService;

    public UserController(IUserService service, IAuthorizationService authorizationService) : base(service)
    {
        _authorizationService = authorizationService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public override ActionResult<IEnumerable<UserReadDTO>> GetAll([FromQuery] GetAllParams options)
    {
        return Ok(_service.GetAll(options));
    }

    [HttpDelete("{id:guid}")]
    public override ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        UserReadDTO foundUser = _service.GetOneById(id);
        if (foundUser is null)
        {
            throw CustomExeption.NotFoundException("User not found");
        }
        else
        {
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundUser, "AdminOrOwnerAccount")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return Ok(_service.DeleteOne(id));
            }
            else if (User.Identity!.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id:guid}")]
    public override ActionResult<UserReadDTO> GetOneById([FromRoute] Guid id)
    {
        return Ok(_service.GetOneById(id));
    }

    //Change later
    [HttpPatch("{id:guid}")]
    public override ActionResult<UserReadDTO> UpdateOne([FromRoute] Guid id, [FromBody] UserUpdateDTO userUpdateDto)
    {
        UserReadDTO foundUser = _service.GetOneById(id);
        if (foundUser is null)
        {
            throw CustomExeption.NotFoundException("User not found");
        }
        else
        {
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundUser, "AdminOrOwnerAccount")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return Ok(_service.UpdateOne(id, userUpdateDto));
            }
            else if (User.Identity!.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }

    [HttpPatch("update-password/{id:guid}")]
    public ActionResult<bool> UpdatePassword([FromRoute] Guid id, [FromBody] PasswordChangeForm passwordChangeForm)
    {
        UserReadDTO foundUser = _service.GetOneById(id);
        if (foundUser is null)
        {
            throw CustomExeption.NotFoundException("User not found");
        }
        else
        {
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundUser, "AdminOrOwnerAccount")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return Ok(_service.UpdatePassword(passwordChangeForm, id));
            }
            else if (User.Identity!.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }

    [HttpPost("email-avaiable")]
    public ActionResult<bool> EmailAvailable([FromBody] string email)
    {
        return Ok(_service.EmailAvailable(email));
    }
}
