using Walmad.Business.src.DTO;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface IAuthService
{
    string Login(Credentials credentials);
    UserReadDTO GetCurrentProfile(string token);
}