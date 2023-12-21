using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class ProductReadDTO : BaseEntity
{
  public int Inventory { get; set; }
  public string Title { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public CategoryReadDTO Category { get; set; }
  public IEnumerable<ProductImageReadDTO> Images { get; set; }
}

public class ProductCreateDTO
{
  public int Inventory { get; set; }
  public string Title { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public Guid categoryId { get; set; }
  public IEnumerable<ProductImageCreateDTO> Images { get; set; }
}

public class ProductUpdateDTO
{
  public int Inventory { get; set; }
  public string Title { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public Guid categoryId { get; set; }
  public IEnumerable<ProductImageCreateDTO> Images { get; set; }
}