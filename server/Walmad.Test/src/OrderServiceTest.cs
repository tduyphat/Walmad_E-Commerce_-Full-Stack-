using AutoMapper;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Parameter;
using Walmad.Core.src.Entity;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Service;
using Walmad.Business.src.Shared;
using Moq;


namespace Walmad.Test.src;

public class OrderServiceTest
{
    private static IMapper _mapper;

    public OrderServiceTest()
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
    public void GetAllOrders_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IOrderRepo>();
        var mapper = new Mock<IMapper>();
        var productRepo = new Mock<IProductRepo>();
        var userRepo = new Mock<IUserRepo>();
        var orderService = new OrderService(repo.Object, _mapper, userRepo.Object, productRepo.Object);
        var options = new GetAllParams { Limit = 120, Offset = 0, sortType = SortType.byTitle, sortOrder = SortOrder.asc };

        orderService.GetAll(options);

        repo.Verify(repo => repo.GetAll(options), Times.Once);
    }

    [Fact]
    public void GetOrderById_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IOrderRepo>();
        Order order = new Order() { };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(order);
        var mapper = new Mock<IMapper>();
        var productRepo = new Mock<IProductRepo>();
        var userRepo = new Mock<IUserRepo>();
        var orderService = new OrderService(repo.Object, _mapper, userRepo.Object, productRepo.Object);

        orderService.GetOneById(It.IsAny<Guid>());

        repo.Verify(repo => repo.GetOneById(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public void DeleteOrder_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IOrderRepo>();
        Order order = new Order() { };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(order);
        var mapper = new Mock<IMapper>();
        var productRepo = new Mock<IProductRepo>();
        var userRepo = new Mock<IUserRepo>();
        var orderService = new OrderService(repo.Object, _mapper, userRepo.Object, productRepo.Object);

        orderService.DeleteOne(It.IsAny<Guid>());

        repo.Verify(repo => repo.DeleteOne(It.IsAny<Order>()), Times.Once);
    }

    [Fact]
    public void UpdateOrder_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IOrderRepo>();
        Order order = new Order() { };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(order);
        var mapper = new Mock<IMapper>();
        var productRepo = new Mock<IProductRepo>();
        var userRepo = new Mock<IUserRepo>();
        var orderService = new OrderService(repo.Object, _mapper, userRepo.Object, productRepo.Object);
        OrderUpdateDTO orderUpdateDto = new OrderUpdateDTO() { OrderStatus = OrderStatus.Shipping };

        orderService.UpdateOne(It.IsAny<Guid>(), orderUpdateDto);

        repo.Verify(repo => repo.UpdateOne(It.IsAny<Order>()), Times.Once);
    }
}
