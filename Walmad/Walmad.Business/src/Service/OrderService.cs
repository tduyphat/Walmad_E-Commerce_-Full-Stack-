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

    public override OrderReadDTO CreateOne(OrderCreateDTO orderCreateDto)
    {
        var newOrder = _mapper.Map<OrderCreateDTO, Order>(orderCreateDto);
        var foundUser = _userRepo.GetOneById(orderCreateDto.UserId);
        if (foundUser is not null)
        {
            newOrder.User = foundUser;
            foreach (var orderProduct in orderCreateDto.OrderProducts)
            {
                var foundProduct = _productRepo.GetOneById(orderProduct.ProductId);
                if (foundProduct is not null)
                {
                    var newOrderProduct = new OrderProduct { Product = foundProduct, Quantity = orderProduct.Quantity };
                    newOrder.OrderProducts.ToList().Add(newOrderProduct);
                }
                else
                {
                    throw CustomExeption.NotFoundException();
                }
            }
            var result = _repo.CreateOne(newOrder);
            return _mapper.Map<Order, OrderReadDTO>(result);
        }
        else
        {
            throw CustomExeption.NotFoundException();
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
