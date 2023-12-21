namespace Walmad.Core.src.Entity;

public class Address : BaseEntity
{
    public int HouseNumber { get; set; }
    public string Street { get; set; }
    public int PostCode { get; set; }
}
