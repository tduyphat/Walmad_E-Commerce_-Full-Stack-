using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

[ApiController]
[Route("api/v1/[controller]s")]
public class BaseController<T, TReadDTO, TCreateDTO, TUpdateDTO, TService> : ControllerBase 
where T : BaseEntity
where TService : IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>
{
    protected readonly TService _service;

    public BaseController(TService service)
    {
        _service = service;
    }

    [HttpPost()]
    public virtual ActionResult<TReadDTO> CreateOne([FromBody] TCreateDTO createObject)
    {
        return CreatedAtAction(nameof(CreateOne), _service.CreateOne(createObject));
    }

    [HttpDelete("{id:guid}")]
    public virtual ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        return Ok(_service.DeleteOne(id));
    }

    [HttpGet()]
    public virtual ActionResult<IEnumerable<TReadDTO>> GetAll([FromQuery] GetAllParams options)
    {
        return Ok(_service.GetAll(options));
    }

    [HttpGet("{id:guid}")]
    public virtual ActionResult<TReadDTO> GetOneById([FromRoute] Guid id)
    {
        return Ok(_service.GetOneById(id));
    }

    [HttpPatch("{id:guid}")]
    public virtual ActionResult<TReadDTO> UpdateOne([FromRoute] Guid id, [FromBody] TUpdateDTO updateObject)
    {
        return Ok(_service.UpdateOne(id, updateObject));
    }
}
