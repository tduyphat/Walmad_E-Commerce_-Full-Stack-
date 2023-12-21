using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface IUserService : IBaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>
{
    // IEnumerable<UserReadDTO> GetAll(GetAllParams options);
    // UserReadDTO GetOneById(Guid id);
    // UserReadDTO CreateOne(UserCreateDTO userCreateDto);
    // UserReadDTO UpdateOne(Guid id, UserUpdateDTO userUpdateDto);
    // bool DeleteOne(Guid id);
    bool UpdatePassword(string newPassword, Guid id);
}
