using System.Text.Json.Serialization;

namespace Walmad.Core.src.Entity;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }
    public byte[] Salt { get; set; } // random key to hash password
    public Role Role { get; set; } = Role.Customer;
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public int PostCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Role
{
    Admin,
    Customer
}
