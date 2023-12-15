using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class ProductCreateAndUpdateDTO
{
  public string Title { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public Category Category { get; set; }
  public IEnumerable<ProductImage> Images { get; set; }
}