using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class UserReadDTO : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }
    public Role Role { get; set; }
    public IEnumerable<AddressReadDTO> Addresses { get; set; }
}

public class UserUpdateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }
    public Role Role { get; set; }
}

public class UserCreateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }
    public Role Role { get; set; } = Role.Customer;
    public IEnumerable<AddressCreateDTO> Addresses { get; set; }
}

