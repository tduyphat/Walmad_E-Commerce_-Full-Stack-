using Microsoft.EntityFrameworkCore;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class UserRepo : BaseRepo<User>, IUserRepo
{
    public UserRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public override IEnumerable<User> GetAll(GetAllParams options)
    {
        return _data.Skip(options.Offset).Take(options.Limit).ToArray();
    }

    public User? FindByEmail(string email)
    {
        return _data.AsNoTracking().FirstOrDefault(user => user.Email == email);
    }
}
