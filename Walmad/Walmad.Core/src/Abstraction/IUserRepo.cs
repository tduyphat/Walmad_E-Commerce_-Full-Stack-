using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Core.src.Abstraction;

public interface IUserRepo
{
    IEnumerable<User> GetAll(GetAllParams options);
    User GetOneById(Guid id);
    User CreateOne(User user);
    User UpdateOne(Guid id, User user);
    bool DeleteOne(Guid id);
    User FindUserByCredentials(User user);
    string GenerateToken(User user);
}
