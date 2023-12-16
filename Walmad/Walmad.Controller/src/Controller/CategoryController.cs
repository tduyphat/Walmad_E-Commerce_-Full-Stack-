using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

[ApiController]
[Route("api/v1/[controller]s")]
public class CategoryController : ControllerBase
{
  private ICategoryService _categoryService;

  public CategoryController(ICategoryService categoryService)
  {
    _categoryService = categoryService;
  }

  [HttpGet()]
  public ActionResult<IEnumerable<CategoryReadDTO>> GetAll()
  {
    return Ok(_categoryService.GetAll());
  }

  [HttpGet("{id:Guid}")]
  public ActionResult<CategoryReadDTO> GetOneById([FromRoute] Guid id)
  {
    return Ok(_categoryService.GetOneById(id));
  }

  [HttpPost()]
  public ActionResult<CategoryReadDTO> CreateOne([FromBody] CategoryCreateAndUpdateDTO categoryCreateAndUpdateDto)
  {
    return CreatedAtAction(nameof(CreateOne), _categoryService.CreateOne(categoryCreateAndUpdateDto));
  }

  [HttpPatch("{id:Guid}")]
  public ActionResult<CategoryReadDTO> UpdateOne([FromRoute] Guid id, CategoryCreateAndUpdateDTO categoryCreateAndUpdateDto)
  {
    return Ok(_categoryService.UpdateOne(id, categoryCreateAndUpdateDto));
  }

  [HttpDelete("{id:Guid}")]
  public ActionResult<CategoryReadDTO> DeleteOne([FromRoute] Guid id)
  {
    return Ok(_categoryService.DeleteOne(id));
  }
}