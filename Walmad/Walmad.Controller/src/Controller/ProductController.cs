using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Walmad.Controller.src.Controller;

[ApiController]
[Route("api/v1/[controller]s")]
public class ProductController : BaseController<Product, ProductReadDTO, ProductCreateDTO, ProductUpdateDTO, IProductService>
{
    public ProductController(IProductService service) : base(service)
    {
    }

    [Authorize(Roles = "Admin")]
    [HttpPost()]
    public override ActionResult<ProductReadDTO> CreateOne([FromBody] ProductCreateDTO productCreateDto)
    {
        return CreatedAtAction(nameof(CreateOne), _service.CreateOne(productCreateDto));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    public override ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        return Ok(_service.DeleteOne(id));
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("{id:guid}")]
    public override ActionResult<ProductReadDTO> UpdateOne([FromRoute] Guid id, [FromBody] ProductUpdateDTO productUpdateDto)
    {
        return Ok(_service.UpdateOne(id, productUpdateDto));
    }

    [HttpGet("category/{categoryId:guid}")]
    public ActionResult<IEnumerable<ProductReadDTO>> GetByCategory([FromRoute] Guid categoryId)
    {
        return Ok(_service.GetByCategory(categoryId));
    }

    [HttpGet("top/{topNumber:int}")]
    public ActionResult<IEnumerable<ProductReadDTO>> GetMostPurchased([FromRoute] int topNumber)
    {
        return Ok(_service.GetMostPurchased(topNumber));
    }
}