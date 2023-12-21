using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class AddressReadDTO : BaseEntity
{
    public int HouseNumber { get; set; }
    public string Street { get; set; }
    public int PostCode { get; set; }
}

public class AddressCreateDTO
{
    public int HouseNumber { get; set; }
    public string Street { get; set; }
    public int PostCode { get; set; }
}

public class AddressUpdateDTO
{
    public int HouseNumber { get; set; }
    public string Street { get; set; }
    public int PostCode { get; set; }
}
