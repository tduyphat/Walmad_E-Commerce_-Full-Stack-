using Walmad.Core.src.Entity;

namespace Walmad.Core.src.Abstraction;

public interface IOrderRepo : IBaseRepo<Order>
{
  IEnumerable<Order> GetByUser(Guid userId);
}
