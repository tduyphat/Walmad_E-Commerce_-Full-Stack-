using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

[ApiController]
[Route("api/v1/[controller]s")]
public class ProductController : ControllerBase
{
  private IProductService _productService;

  public ProductController(IProductService productService)
  {
    _productService = productService;
  }

  [HttpGet()]
  public ActionResult<IEnumerable<Product>> GetAll([FromQuery] GetAllParams options)
  {
    return Ok(_productService.GetAll(options));
  }

  [HttpGet("{id:Guid}")]
  public ActionResult<Product> GetOneById([FromRoute] Guid id)
  {
    return Ok(_productService.GetOneById(id));
  }

  [HttpPost()]
  public ActionResult<Product> CreateOne([FromBody] ProductCreateAndUpdateDTO productCreateAndUpdateDto)
  {
    return CreatedAtAction(nameof(CreateOne), _productService.CreateOne(productCreateAndUpdateDto));
  }

  [HttpPatch("{id:Guid}")]
  public ActionResult<Product> UpdateOne([FromRoute] Guid id, ProductCreateAndUpdateDTO productCreateAndUpdateDto)
  {
    return Ok(_productService.UpdateOne(id, productCreateAndUpdateDto));
  }

  [HttpDelete("{id:Guid}")]
  public ActionResult<Product> DeleteOne([FromRoute] Guid id)
  {
    return Ok(_productService.DeleteOne(id));
  }
}