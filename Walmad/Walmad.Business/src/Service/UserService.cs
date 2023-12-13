using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Service;

public class UserService : IUserService
{
    private IUserRepo _userRepo;

    public UserService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public IEnumerable<UserReadDTO> GetAll(GetAllParams options)
    {
        return _userRepo.GetAll(options).Select(user => new UserReadDTO().Convert(user));
    }

    public UserReadDTO GetOneById(Guid id)
    {
        var result = _userRepo.GetOneById(id);
        var userReadDto = new UserReadDTO();
        return userReadDto.Convert(result);
    }

    public UserReadDTO CreateOne(UserCreateDTO userCreateDto)
    {
        var result = _userRepo.CreateOne(userCreateDto.Transform());
        var userReadDto = new UserReadDTO();
        return userReadDto.Convert(result);
    }

    public UserReadDTO UpdateOne(Guid id, UserUpdateDTO userUpdateDto)
    {

        var result = _userRepo.UpdateOne(id, userUpdateDto.Transform());
        var userReadDto = new UserReadDTO();
        return userReadDto.Convert(result);
    }

    public bool DeleteOne(Guid id)
    {
        var result = _userRepo.DeleteOne(id);
        return result;
    }
}
