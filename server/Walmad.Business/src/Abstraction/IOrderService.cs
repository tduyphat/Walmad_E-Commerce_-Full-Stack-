using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Abstraction;

public interface IOrderService : IBaseService<Order, OrderReadDTO, OrderCreateDTO, OrderUpdateDTO>
{
    IEnumerable<OrderReadDTO> GetByUser(Guid userId);
    OrderReadDTO CreateOne(Guid userId, OrderCreateDTO orderCreateDto);
    bool CancelOrder(Guid id);
}
