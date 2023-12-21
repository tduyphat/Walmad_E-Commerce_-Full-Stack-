using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

public class AddressController : BaseController<Address, AddressReadDTO, AddressCreateDTO, AddressUpdateDTO, IAddressService>
{
    public AddressController(IAddressService service) : base(service)
    {
    }

    [HttpDelete("{id:guid}")]
    public override ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        return Ok(_service.DeleteOne(id));
    }

    // [Authorize(Roles = "Admin")]
    [HttpGet()]
    public override ActionResult<IEnumerable<AddressReadDTO>> GetAll([FromQuery] GetAllParams options)
    {
        return Ok(_service.GetAll(options));
    }

    [HttpGet("{id:guid}")]
    public override ActionResult<AddressReadDTO> GetOneById([FromRoute] Guid id)
    {
        return Ok(_service.GetOneById(id));
    }

    [HttpPatch("{id:guid}")]
    public override ActionResult<AddressReadDTO> UpdateOne([FromRoute] Guid id, [FromBody] AddressUpdateDTO addressUpdateDto)
    {
        return Ok(_service.UpdateOne(id, addressUpdateDto));
    }
}
