using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Core.src.Abstraction;

public interface IUserRepo : IBaseRepo<User>
{
    User? FindByEmail(string email);
}
