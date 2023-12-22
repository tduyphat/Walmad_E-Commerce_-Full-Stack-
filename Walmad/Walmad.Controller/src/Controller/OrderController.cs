using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

public class OrderController : BaseController<Order, OrderReadDTO, OrderCreateDTO, OrderUpdateDTO, IOrderService>
{
    public OrderController(IOrderService service) : base(service)
    {
    }

    // [Authorize(Roles = "Customer")]
    [HttpPost()]
    public override ActionResult<OrderReadDTO> CreateOne([FromBody] OrderCreateDTO orderCreateDto)
    {
        return CreatedAtAction(nameof(CreateOne), _service.CreateOne(orderCreateDto));
    }

    // [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    public override ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        return Ok(_service.DeleteOne(id));
    }

    [HttpGet()]
    public override ActionResult<IEnumerable<OrderReadDTO>> GetAll([FromQuery] GetAllParams options)
    {
        return Ok(_service.GetAll(options));
    }

    [HttpGet("{id:guid}")]
    public override ActionResult<OrderReadDTO> GetOneById([FromRoute] Guid id)
    {
        return Ok(_service.GetOneById(id));
    }

    [HttpPatch("{id:guid}")]
    public override ActionResult<OrderReadDTO> UpdateOne([FromRoute] Guid id, [FromBody] OrderUpdateDTO orderUpdateDto)
    {
        return Ok(_service.UpdateOne(id, orderUpdateDto));
    }

    [HttpGet("user/{userId:guid}")]
    public ActionResult<IEnumerable<OrderReadDTO>> GetByUser([FromRoute] Guid userId)
    {
        return Ok(_service.GetByUser(userId));
    }
}
