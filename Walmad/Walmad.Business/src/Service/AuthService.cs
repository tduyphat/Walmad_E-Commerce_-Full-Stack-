using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Service;

public class AuthService : IAuthService
{
  private IUserRepo _userRepo;
  private ITokenService _tokenService;
  private IMapper _mapper;

  public AuthService(IUserRepo userRepo, ITokenService tokenService, IMapper mapper)
  {
    _userRepo = userRepo;
    _tokenService = tokenService;
    _mapper = mapper;
  }

  public UserReadDTO GetCurrentProfile(Guid id)
  {
    var foundUser = _userRepo.GetOneById(id);
    if (foundUser != null)
    {
      return _mapper.Map<User, UserReadDTO>(foundUser);
    }
    throw CustomExeption.NotFoundException();
  }

  public string Login(Credentials credentials)
  {
    var foundByEmail = _userRepo.FindByEmail(credentials.Email);
    if (foundByEmail is null)
    {
      throw CustomExeption.NotFoundException();
    }
    var isPasswordMatch = PasswordService.VerifyPassword(credentials.Password, foundByEmail.Password, foundByEmail.Salt);
    if (isPasswordMatch)
    {
      return _tokenService.GenerateToken(foundByEmail);
    }
    throw CustomExeption.UnauthorizedException();
  }
}