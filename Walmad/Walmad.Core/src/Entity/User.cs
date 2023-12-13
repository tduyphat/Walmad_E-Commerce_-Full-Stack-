namespace Walmad.Core.src.Entity;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }
    public Role Role { get; set; }
}

public enum Role
{
    Admin,
    Customer
}
