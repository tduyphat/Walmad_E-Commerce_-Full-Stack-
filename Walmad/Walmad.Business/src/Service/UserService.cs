using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Service;

public class UserService : IUserService
{
    private IUserRepo _userRepo;
    private IMapper _mapper;

    public UserService(IUserRepo userRepo, IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }

    public IEnumerable<UserReadDTO> GetAll(GetAllParams options)
    {
        var result = _userRepo.GetAll(options);
        return _mapper.Map<IEnumerable<User>, IEnumerable<UserReadDTO>>(result);
    }

    public UserReadDTO GetOneById(Guid id)
    {
        var result = _userRepo.GetOneById(id);
        return _mapper.Map<User, UserReadDTO>(result);
    }

    public UserReadDTO CreateOne(UserCreateDTO userCreateDto)
    {
        var result = _userRepo.CreateOne(_mapper.Map<UserCreateDTO, User>(userCreateDto));
        return _mapper.Map<User, UserReadDTO>(result);
    }

    public UserReadDTO UpdateOne(Guid id, UserUpdateDTO userUpdateDto)
    {

        var result = _userRepo.UpdateOne(id, _mapper.Map<UserUpdateDTO, User>(userUpdateDto));
        return _mapper.Map<User, UserReadDTO>(result);
    }

    public bool DeleteOne(Guid id)
    {
        var result = _userRepo.DeleteOne(id);
        return result;
    }
}
