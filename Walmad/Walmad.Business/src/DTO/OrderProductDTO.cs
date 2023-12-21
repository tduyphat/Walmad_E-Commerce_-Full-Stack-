using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class OrderProductReadDTO
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}

public class OrderProductCreateDTO
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
