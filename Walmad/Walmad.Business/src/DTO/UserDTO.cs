using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class UserReadDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }
    public Role Role { get; set; }
}

public class UserUpdateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }
}

public class UserCreateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }
}

