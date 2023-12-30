using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class UserReadDTO : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }
    public Role Role { get; set; } = Role.Customer;
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public int PostCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

public class UserUpdateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }
    // public Role Role { get; set; } = Role.Customer;
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public int PostCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

public class UserCreateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }
    // public Role Role { get; set; } = Role.Customer;
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public int PostCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

public class UserRoleUpdateDTO
{
    public Role Role { get; set; }
}

