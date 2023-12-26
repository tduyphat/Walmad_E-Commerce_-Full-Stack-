using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface IUserService : IBaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>
{
    bool UpdatePassword(PasswordChangeForm passwordChangeForm, Guid id);
    bool EmailAvailable(string email);
}
