using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class CategoryReadDTO : BaseEntity
{
  public string Name { get; set; }
  public string Image { get; set; }
}

public class CategoryCreateDTO
{
  public string Name { get; set; }
  public string Image { get; set; }
}

public class CategoryUpdateDTO
{
  public string? Name { get; set; }
  public string? Image { get; set; }
}