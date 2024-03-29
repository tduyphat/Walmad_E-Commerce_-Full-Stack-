using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.Controller.src.Controller;

[ApiController]
[Route("api/v1/[controller]s")]
public class CategoryController : BaseController<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO, ICategoryService>
{
    public CategoryController(ICategoryService service) : base(service)  
    {
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost()]
    public override ActionResult<CategoryReadDTO> CreateOne([FromBody] CategoryCreateDTO categoryCreateDto)
    {
        return CreatedAtAction(nameof(CreateOne), _service.CreateOne(categoryCreateDto));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    public override ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        return Ok(_service.DeleteOne(id));
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("{id:guid}")]
    public override ActionResult<CategoryReadDTO> UpdateOne([FromRoute] Guid id, [FromBody] CategoryUpdateDTO categoryUpdateDto)
    {
        return Ok(_service.UpdateOne(id, categoryUpdateDto));
    }
}