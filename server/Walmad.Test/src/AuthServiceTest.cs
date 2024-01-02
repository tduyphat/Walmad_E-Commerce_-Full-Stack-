using AutoMapper;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Business.src.Service;
using Walmad.Business.src.Shared;
using Moq;
using Walmad.Business.src.Abstraction;

namespace Walmad.Test.src;

public class AuthServiceTest
{
    private static IMapper _mapper;

    public AuthServiceTest()
    {
        if (_mapper == null)
        {
            var mappingConfig = new MapperConfiguration(map =>
            {
                map.AddProfile(new MapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
    }

    [Fact]
    public void GetCurrentProfile_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IUserRepo>();
        User user = new User() { };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(user);
        var mapper = new Mock<IMapper>();
        var tokenService = new Mock<ITokenService>();
        var authService = new AuthService(repo.Object, tokenService.Object, _mapper);

        authService.GetCurrentProfile(It.IsAny<Guid>());

        repo.Verify(repo => repo.GetOneById(It.IsAny<Guid>()), Times.Once);
    }
}
