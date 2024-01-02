using AutoMapper;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Parameter;
using Walmad.Core.src.Entity;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Service;
using Walmad.Business.src.Shared;
using Moq;

namespace Walmad.Test.src;

public class UserServiceTest
{
    private static IMapper _mapper;
    public UserServiceTest()
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
    public void GetAllUsers_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IUserRepo>();
        var mapper = new Mock<IMapper>();
        var userService = new UserService(repo.Object, _mapper);
        var options = new GetAllParams { Limit = 120, Offset = 0, sortType = SortType.byTitle, sortOrder = SortOrder.asc };

        userService.GetAll(options);

        repo.Verify(repo => repo.GetAll(options), Times.Once);
    }

    [Fact]
    public void GetUserById_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IUserRepo>();
        User user = new User() { Name = "maria", Email = "maria@mail.com", Password = "1234", Avatar = "https://picsum.photos/200" };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(user);
        var mapper = new Mock<IMapper>();
        var userService = new UserService(repo.Object, _mapper);

        userService.GetOneById(It.IsAny<Guid>());

        repo.Verify(repo => repo.GetOneById(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public void CreateUser_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IUserRepo>();
        var mapper = new Mock<IMapper>();
        var userService = new UserService(repo.Object, _mapper);
        UserCreateDTO userCreateDto = new UserCreateDTO() { Name = "maria", Email = "maria@mail.com", Password = "1234", Avatar = "https://picsum.photos/200" };

        userService.CreateOne(userCreateDto);

        repo.Verify(repo => repo.CreateOne(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public void DeleteUser_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IUserRepo>();
        User user = new User() { Name = "maria", Email = "maria@mail.com", Password = "1234", Avatar = "https://picsum.photos/200" };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(user);
        var mapper = new Mock<IMapper>();
        var userService = new UserService(repo.Object, _mapper);

        userService.DeleteOne(It.IsAny<Guid>());

        repo.Verify(repo => repo.DeleteOne(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public void UpdateUser_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IUserRepo>();
        User user = new User() { };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(user);
        var mapper = new Mock<IMapper>();
        var orderService = new UserService(repo.Object, _mapper);
        UserUpdateDTO userUpdateDto = new UserUpdateDTO() { };

        orderService.UpdateOne(It.IsAny<Guid>(), userUpdateDto);

        repo.Verify(repo => repo.UpdateOne(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public void EmailAvailable_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IUserRepo>();
        var mapper = new Mock<IMapper>();
        var userService = new UserService(repo.Object, _mapper);

        userService.EmailAvailable(It.IsAny<string>());

        repo.Verify(repo => repo.FindByEmail(It.IsAny<string>()), Times.Once);
    }
}
