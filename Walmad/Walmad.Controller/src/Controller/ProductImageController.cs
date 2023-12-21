using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

public class ProductImageController : BaseController<ProductImage, ProductImageReadDTO, ProductImageCreateDTO, ProductImageUpdateDTO, IProductImageService>
{
    public ProductImageController(IProductImageService service) : base(service)
    {
    }

    // [Authorize(Roles = "Admin")]
    [HttpPost()]
    public override ActionResult<ProductImageReadDTO> CreateOne([FromBody] ProductImageCreateDTO productImageCreateDto)
    {
        return CreatedAtAction(nameof(CreateOne), _service.CreateOne(productImageCreateDto));
    }

    // [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    public override ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        return Ok(_service.DeleteOne(id));
    }

    [HttpGet()]
    public override ActionResult<IEnumerable<ProductImageReadDTO>> GetAll([FromQuery] GetAllParams options)
    {
        return Ok(_service.GetAll(options));
    }

    [HttpGet("{id:guid}")]
    public override ActionResult<ProductImageReadDTO> GetOneById([FromRoute] Guid id)
    {
        return Ok(_service.GetOneById(id));
    }

    // [Authorize(Roles = "Admin")]
    [HttpPatch("{id:guid}")]
    public override ActionResult<ProductImageReadDTO> UpdateOne([FromRoute] Guid id, [FromBody] ProductImageUpdateDTO productImageUpdateDto)
    {
        return Ok(_service.UpdateOne(id, productImageUpdateDto));
    }
}
