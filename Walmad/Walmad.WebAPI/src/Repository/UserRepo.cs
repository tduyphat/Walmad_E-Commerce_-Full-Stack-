using Microsoft.EntityFrameworkCore;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class UserRepo : BaseRepo<User>, IUserRepo
{
    public UserRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
    public User? FindByEmail(string email)
    {
        return _data.AsNoTracking().FirstOrDefault(user => user.Email == email);
    }
}
