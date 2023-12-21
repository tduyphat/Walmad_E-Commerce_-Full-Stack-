using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Abstraction;

public interface IOrderService : IBaseService<Order, OrderReadDTO, OrderCreateDTO, OrderUpdateDTO>
{
    IEnumerable<OrderReadDTO> GetByUser(Guid userId);
}
