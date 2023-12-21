using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Abstraction;

public interface ITokenService
{
    string GenerateToken(User user);
    Guid GetCurrentProfile(string token);
}
