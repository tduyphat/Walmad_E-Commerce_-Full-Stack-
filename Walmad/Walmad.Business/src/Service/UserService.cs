using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Service;

public class UserService : BaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO, IUserRepo>, IUserService
{
    public UserService(IUserRepo repo, IMapper mapper) : base(repo, mapper)
    {
    }

    public override UserReadDTO CreateOne(UserCreateDTO userCreateDto)
    {
       PasswordService.HashPassword(userCreateDto.Password, out string hashedPassword, out byte[] salt);
       userCreateDto.Role = Role.Customer;
       var user = _mapper.Map<UserCreateDTO, User>(userCreateDto);
       user.Password = hashedPassword;
       user.Salt = salt;
       var result = _repo.CreateOne(user);
       return _mapper.Map<User, UserReadDTO>(result);
    }
    
    public bool UpdatePassword(string newPassword, Guid id)
    {
        var user = _repo.GetOneById(id);
        if (user is null)
        {
            throw CustomExeption.NotFoundException();
        }
        PasswordService.HashPassword(newPassword, out string hashedPassword, out byte[] salt);
        user.Password = hashedPassword;
        user.Salt = salt;
        _repo.UpdateOne(user);
        return true;
    }
}
