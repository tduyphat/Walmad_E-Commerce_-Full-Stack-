using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

[ApiController]
[Route("api/[controller]s")]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet()]
    public ActionResult<IEnumerable<UserReadDTO>> GetAll([FromQuery] GetAllParams options)
    {
        return Ok(_userService.GetAll(options));
    }

    [HttpGet("{id:Guid}")]
    public ActionResult<UserReadDTO> GetOneById([FromRoute] Guid id)
    {
        return Ok(_userService.GetOneById(id));
    }

    [HttpPost()]
    public ActionResult<UserReadDTO> CreateOne([FromBody] UserCreateDTO userCreateDto)
    {
        return CreatedAtAction(nameof(CreateOne), _userService.CreateOne(userCreateDto));
    }

    [HttpPatch("{id:Guid}")]
    public ActionResult<UserReadDTO> UpdateOne([FromRoute] Guid id, UserUpdateDTO userUpdateDto)
    {
        return Ok(_userService.UpdateOne(id, userUpdateDto));
    }

    [HttpDelete("{id:Guid}")]
    public ActionResult<UserReadDTO> DeleteOne([FromRoute] Guid id)
    {
        return Ok(_userService.DeleteOne(id));
    }
}
