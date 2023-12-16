namespace Walmad.Business.src.DTO;

public class CategoryReadDTO
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Image { get; set; }
}

public class CategoryCreateAndUpdateDTO
{
  public string Name { get; set; }
  public string Image { get; set; }
}