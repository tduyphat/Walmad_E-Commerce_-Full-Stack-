namespace Walmad.Core.src.Entity;

public class Review : BaseEntity
{
    public byte Rating { get; set; }
    public string Content { get; set; }
    public User User { get; set; }
}
