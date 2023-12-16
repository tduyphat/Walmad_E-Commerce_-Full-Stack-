namespace Walmad.Core.src.Entity;

public class Order : BaseEntity
{
    public User User { get; set; }
    public IEnumerable<OrderProduct> OrderProducts { get; set; }
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipping,
    Shipped,
}
