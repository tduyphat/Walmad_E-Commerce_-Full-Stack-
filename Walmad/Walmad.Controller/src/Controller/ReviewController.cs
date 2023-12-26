using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

public class ReviewController : BaseController<Review, ReviewReadDTO, ReviewCreateDTO, ReviewUpdateDTO, IReviewService>
{
    private readonly IAuthorizationService _authorizationService;

    public ReviewController(IReviewService service, IAuthorizationService authorizationService) : base(service)
    {
        _authorizationService = authorizationService;
    }

    [Authorize(Roles = "Customer")]
    [HttpPost()]
    public override ActionResult<ReviewReadDTO> CreateOne([FromBody] ReviewCreateDTO reviewCreateDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return CreatedAtAction(nameof(CreateOne), _service.CreateOne(Guid.Parse(userId), reviewCreateDto));
    }

    [HttpDelete("{id:guid}")]
    public override ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        ReviewReadDTO? foundReview = _service.GetOneById(id);
        if (foundReview is null)
        {
            throw CustomExeption.NotFoundException("Review not found");
        }
        else
        {
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundReview, "AdminOrOwnerReview")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return Ok(_service.DeleteOne(id));
            }
            else if (User.Identity!.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public override ActionResult<IEnumerable<ReviewReadDTO>> GetAll([FromQuery] GetAllParams options)
    {
        return Ok(_service.GetAll(options));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id:guid}")]
    public override ActionResult<ReviewReadDTO> GetOneById([FromRoute] Guid id)
    {
        return Ok(_service.GetOneById(id));
    }

    [HttpGet("product/{id:guid}")]
    public ActionResult<ReviewReadDTO> GetByProduct([FromRoute] Guid id)
    {
        return Ok(_service.GetByProduct(id));
    }

    //Change later
    [HttpPatch("{id:guid}")]
    public override ActionResult<ReviewReadDTO> UpdateOne([FromRoute] Guid id, [FromBody] ReviewUpdateDTO reviewUpdateDto)
    {
        ReviewReadDTO? foundReview = _service.GetOneById(id);
        if (foundReview is null)
        {
            throw CustomExeption.NotFoundException("Review not found");
        }
        else
        {
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundReview, "AdminOrOwnerReview")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return Ok(_service.UpdateOne(id, reviewUpdateDto));
            }
            else if (User.Identity!.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }
}
