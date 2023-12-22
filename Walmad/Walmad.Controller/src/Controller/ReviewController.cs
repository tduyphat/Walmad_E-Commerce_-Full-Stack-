using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

public class ReviewController : BaseController<Review, ReviewReadDTO, ReviewCreateDTO, ReviewUpdateDTO, IReviewService>
{
    public ReviewController(IReviewService service) : base(service)
    {
    }

    // [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    public override ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        return Ok(_service.DeleteOne(id));
    }

    // [Authorize(Roles = "Admin")]
    [HttpGet()]
    public override ActionResult<IEnumerable<ReviewReadDTO>> GetAll([FromQuery] GetAllParams options)
    {
        return Ok(_service.GetAll(options));
    }

    // [Authorize(Roles = "Admin")]
    [HttpGet("{id:guid}")]
    public override ActionResult<ReviewReadDTO> GetOneById([FromRoute] Guid id)
    {
        return Ok(_service.GetOneById(id));
    }

    // [Authorize(Roles = "Admin")]
    [HttpPatch("{id:guid}")]
    public override ActionResult<ReviewReadDTO> UpdateOne([FromRoute] Guid id, [FromBody] ReviewUpdateDTO reviewUpdateDto)
    {
        return Ok(_service.UpdateOne(id, reviewUpdateDto));
    }
}