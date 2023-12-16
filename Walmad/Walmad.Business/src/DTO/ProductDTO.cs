using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class ProductReadDTO
{
  public Guid Id { get; set; }
  public string Title { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public CategoryReadDTO Category { get; set; }
  public IEnumerable<ProductImageReadDTO> Images { get; set; }
}

public class ProductCreateAndUpdateDTO
{
  public string Title { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public CategoryReadDTO Category { get; set; }
  public IEnumerable<ProductImageReadDTO> Images { get; set; }
}