using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class OrderReadDTO : BaseEntity
{
    public UserReadDTO User { get; set; }
    public IEnumerable<OrderProductReadDTO> OrderProducts { get; set; }
    public OrderStatus OrderStatus { get; set; }
}

public class OrderCreateDTO
{
    public Guid UserId { get; set; }
    public IEnumerable<OrderProductCreateDTO> OrderProducts { get; set; }
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
}

public class OrderUpdateDTO
{
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
}
