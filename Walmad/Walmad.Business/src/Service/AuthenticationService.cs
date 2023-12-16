using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Service;

public class AuthenticationService : IAuthenticationService
{
  private IUserRepo _userRepo;
  private IMapper _mapper;

  public AuthenticationService(IUserRepo userRepo, IMapper mapper)
  {
    _userRepo = userRepo;
    _mapper = mapper;
  }

  public string Login(LoginDTO loginDto)
  {
    var foundUser = _userRepo.FindUserByCredentials(_mapper.Map<LoginDTO, User>(loginDto));
    return _userRepo.GenerateToken(foundUser);
  }
}