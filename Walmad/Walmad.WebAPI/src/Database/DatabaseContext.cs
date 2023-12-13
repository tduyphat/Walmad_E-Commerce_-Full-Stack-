using Walmad.Core.src.Entity;

namespace Walmad.WebAPI.src.Database;

public class DatabaseContext
{
    public List<User> Users { get; set; }

    public DatabaseContext()
    {
        Users = new List<User>{
            new User{ Name = "john", Email = "john@mail.com", Password = "1234", Avatar="www.avatar.com"},
            new User{ Name = "jim", Email = "jim@mail.com", Password = "1234", Avatar="www.avatar1.com"},
            new User{ Name = "maria", Email = "maria@mail.com", Password = "1234", Avatar="www.avatar2.com"}
        };
    }
}
