namespace Walmad.Core.src.Entity;

public class OrderProduct : Timestamp
{
    public Order Order { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}
