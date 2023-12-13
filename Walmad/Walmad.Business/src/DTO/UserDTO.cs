using Walmad.Core.src.Entity;

namespace Walmad.Business.src.DTO;

public class UserReadDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }
    public Role Role { get; set; }

    public UserReadDTO Convert(User user)
    {
        return new UserReadDTO { Id = user.Id, Name = user.Name, Email = user.Email, Avatar = user.Avatar, Role = user.Role };
    }
}

public class UserUpdateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }

    public User Transform()
    {
        return new User { Name = Name, Email = Email, Avatar = Avatar };
    }
}

public class UserCreateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }

    public User Transform()
    {
        return new User { Id = new Guid(), Name = Name, Email = Email, Password = Password, Avatar = Avatar };
    }
}

