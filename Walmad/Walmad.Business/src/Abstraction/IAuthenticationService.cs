using Walmad.Business.src.DTO;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface IAuthenticationService
{
    string Login(LoginDTO loginDto);
}