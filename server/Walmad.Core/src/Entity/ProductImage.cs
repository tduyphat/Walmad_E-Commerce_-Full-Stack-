namespace Walmad.Core.src.Entity;

public class ProductImage : BaseEntity
{
    public Guid ProductId { get; set; }
    public string Url { get; set; }
}
