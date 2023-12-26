using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Service;

public class OrderService : BaseService<Order, OrderReadDTO, OrderCreateDTO, OrderUpdateDTO, IOrderRepo>, IOrderService
{
    private IUserRepo _userRepo;
    private IProductRepo _productRepo;

    public OrderService(IOrderRepo repo, IMapper mapper, IUserRepo userRepo, IProductRepo productRepo) : base(repo, mapper)
    {
        _userRepo = userRepo;
        _productRepo = productRepo;
    }

    public OrderReadDTO CreateOne(Guid userId, OrderCreateDTO orderCreateDto)
    {
        var foundUser = _userRepo.GetOneById(userId);
        if (foundUser is null)
        {
            throw CustomExeption.NotFoundException();
        }
        else
        {
            var order = _mapper.Map<Order>(orderCreateDto);
            order.User = foundUser;
            var newOrderProductList = new List<OrderProduct>();
            foreach (var orderProductDto in orderCreateDto.OrderProducts)
            {
                var foundProduct = _productRepo.GetOneById(orderProductDto.ProductId);
                if (foundProduct == null)
                {
                    throw CustomExeption.NotFoundException("Product not found");
                }
                newOrderProductList.Add(new OrderProduct
                {
                    Product = foundProduct,
                    Quantity = orderProductDto.Quantity,
                });
            }
            order.OrderProducts = newOrderProductList;
            var createdOrder = _repo.CreateOne(order);
            return _mapper.Map<OrderReadDTO>(createdOrder);
        }
    }

    public IEnumerable<OrderReadDTO> GetByUser(Guid userId)
    {
        var foundUser = _userRepo.GetOneById(userId);
        if (foundUser is not null)
        {
            var result = _repo.GetByUser(userId);
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderReadDTO>>(result);
        }
        else
        {
            throw CustomExeption.NotFoundException();
        }
    }
}
