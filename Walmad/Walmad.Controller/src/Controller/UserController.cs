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

    // change later
    [HttpDelete("{id:guid}")]
    public override ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        return Ok(_service.DeleteOne(id));
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
        return Ok(_service.UpdateOne(id, userUpdateDto));
    }

    //Change later
    [HttpPatch("update-password/{id:guid}")]
    public ActionResult<bool> UpdatePassword([FromRoute] Guid id, [FromBody] PasswordChangeForm passwordChangeForm)
    {
        return Ok(_service.UpdatePassword(passwordChangeForm, id));
    }

    [HttpPost("email-avaiable")]
    public ActionResult<bool> EmailAvailable([FromBody] string email)
    {
        return Ok(_service.EmailAvailable(email));
    }
}
