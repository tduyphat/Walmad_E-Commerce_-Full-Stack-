namespace Walmad.Core.src.Entity;

public class OrderProduct : BaseEntity
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}
