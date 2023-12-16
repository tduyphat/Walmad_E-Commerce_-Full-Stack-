namespace Walmad.Core.src.Entity;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public IEnumerable<ProductImage> Images { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
}