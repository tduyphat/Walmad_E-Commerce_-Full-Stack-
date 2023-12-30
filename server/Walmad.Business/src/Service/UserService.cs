using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Service;

public class UserService : BaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO, IUserRepo>, IUserService
{
    public UserService(IUserRepo repo, IMapper mapper) : base(repo, mapper)
    {
    }

    public override UserReadDTO CreateOne(UserCreateDTO userCreateDto)
    {
        PasswordService.HashPassword(userCreateDto.Password, out string hashedPassword, out byte[] salt);
        // userCreateDto.Role = Role.Customer;
        var user = _mapper.Map<UserCreateDTO, User>(userCreateDto);
        user.Role = Role.Customer;
        user.Password = hashedPassword;
        user.Salt = salt;
        var result = _repo.CreateOne(user);
        return _mapper.Map<User, UserReadDTO>(result);
    }

    public bool EmailAvailable(string email)
    {
        var foundEmail = _repo.FindByEmail(email);
        if (foundEmail is null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override UserReadDTO UpdateOne(Guid id, UserUpdateDTO userUpdateDto)
    {
        var foundUser = _repo.GetOneById(id);
        if (foundUser is not null)
        {
            // userUpdateDto.Role = Role.Customer;
            var result = _repo.UpdateOne(_mapper.Map(userUpdateDto, foundUser));
            return _mapper.Map<User, UserReadDTO>(result);
        }
        else
        {
            throw CustomExeption.NotFoundException("Id not found");
        }
    }

    public bool UpdatePassword(PasswordChangeForm passwordChangeForm, Guid id)
    {
        var user = _repo.GetOneById(id);
        if (user is null)
        {
            throw CustomExeption.NotFoundException();
        }
        bool passwordMatch = PasswordService.VerifyPassword(passwordChangeForm.CurrentPassword, user.Password, user.Salt);
        if (!passwordMatch)
        {
            throw CustomExeption.NotFoundException("Current password incorrect");
        }
        else
        {
            PasswordService.HashPassword(passwordChangeForm.NewPassword, out string hashedNewPassword, out byte[] newSalt);
            user.Password = hashedNewPassword;
            user.Salt = newSalt;
            _repo.UpdateOne(user);
            return true;
        }
    }

    public UserReadDTO UpdateRole(Guid id, UserRoleUpdateDTO userRoleUpdateDto)
    {
        var foundUser = _repo.GetOneById(id);
        if (foundUser is not null)
        {
            var result = _repo.UpdateOne(_mapper.Map(userRoleUpdateDto, foundUser));
            return _mapper.Map<User, UserReadDTO>(result);
        }
        else
        {
            throw CustomExeption.NotFoundException("Id not found");
        }
    }
}
