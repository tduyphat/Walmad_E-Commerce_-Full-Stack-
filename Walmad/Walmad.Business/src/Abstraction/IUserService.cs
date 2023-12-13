using Walmad.Business.src.DTO;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface IUserService
{
    IEnumerable<UserReadDTO> GetAll(GetAllParams options);
    UserReadDTO GetOneById(Guid id);
    UserReadDTO CreateOne(UserCreateDTO userCreateDto);
    UserReadDTO UpdateOne(Guid id, UserUpdateDTO userUpdateDto);
    bool DeleteOne(Guid id);
}
