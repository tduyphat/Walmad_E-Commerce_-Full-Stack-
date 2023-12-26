using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Controller.src.Controller;

public class OrderController : BaseController<Order, OrderReadDTO, OrderCreateDTO, OrderUpdateDTO, IOrderService>
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserService _userService;

    public OrderController(IOrderService service, IAuthorizationService authorizationService, IUserService userService) : base(service)
    {
        _authorizationService = authorizationService;
        _userService = userService;
    }

    [Authorize(Roles = "Customer")]
    [HttpPost()]
    public override ActionResult<OrderReadDTO> CreateOne([FromBody] OrderCreateDTO orderCreateDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return CreatedAtAction(nameof(CreateOne), _service.CreateOne(Guid.Parse(userId), orderCreateDto));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    public override ActionResult<bool> DeleteOne([FromRoute] Guid id)
    {
        return Ok(_service.DeleteOne(id));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public override ActionResult<IEnumerable<OrderReadDTO>> GetAll([FromQuery] GetAllParams options)
    {
        return Ok(_service.GetAll(options));
    }

    [HttpGet("{id:guid}")]
    public override ActionResult<OrderReadDTO> GetOneById([FromRoute] Guid id)
    {
        OrderReadDTO? foundOrder = _service.GetOneById(id);
        if (foundOrder is null)
        {
            throw CustomExeption.NotFoundException("Order not found");
        }
        else
        {
            // var authorizationTask = _authorizationService.AuthorizeAsync(HttpContext.User, foundOrder, "AdminOrOwnerOrder");
            // authorizationTask.Wait();
            // var authorizationResult = authorizationTask.Result;

            var authorizationResult = _authorizationService.AuthorizeAsync(HttpContext.User, foundOrder, "AdminOrOwnerOrder")
                .GetAwaiter()
                .GetResult();

            if (authorizationResult.Succeeded)
            {
                return Ok(_service.GetOneById(id));
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
    [HttpPatch("{id:guid}")]
    public override ActionResult<OrderReadDTO> UpdateOne([FromRoute] Guid id, [FromBody] OrderUpdateDTO orderUpdateDto)
    {
        return Ok(_service.UpdateOne(id, orderUpdateDto));
    }

    [HttpGet("user/{userId:guid}")]
    public ActionResult<IEnumerable<OrderReadDTO>> GetByUser([FromRoute] Guid userId)
    {
        UserReadDTO foundUser = _userService.GetOneById(userId);
        if (foundUser is null)
        {
            throw CustomExeption.NotFoundException("User not found");
        }
        else
        {
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundUser, "AdminOrOwnerAccount")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return Ok(_service.GetByUser(userId));
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

    [HttpPatch("cancel-order/{id:guid}")]
    public ActionResult<bool> CancelOrder([FromRoute] Guid id)
    {
        OrderReadDTO? foundOrder = _service.GetOneById(id);
        if (foundOrder is null)
        {
            throw CustomExeption.NotFoundException("Order not found");
        }
        else
        {
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundOrder, "AdminOrOwnerOrder")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return Ok(_service.CancelOrder(id));
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