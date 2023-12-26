using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class ReviewReadDTO : BaseEntity
{
    public byte Rating { get; set; }
    public string Content { get; set; }
    public UserReadDTO User { get; set; }
    public ProductReadDTO Product { get; set; }
}

public class ReviewCreateDTO
{
    public byte Rating { get; set; }
    public string Content { get; set; }
    public Guid ProductID { get; set; }
}

public class ReviewUpdateDTO
{
    public byte Rating { get; set; }
    public string Content { get; set; }
}
