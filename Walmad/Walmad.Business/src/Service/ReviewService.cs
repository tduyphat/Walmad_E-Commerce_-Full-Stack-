using AutoMapper;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Service;

public class ReviewService : BaseService<Review, ReviewReadDTO, ReviewCreateDTO, ReviewUpdateDTO, IReviewRepo>, IReviewService
{
    private IProductRepo _productRepo;
    private IUserRepo _userRepo;

    public ReviewService(IReviewRepo repo, IMapper mapper, IProductRepo productRepo, IUserRepo userRepo) : base(repo, mapper)
    {
        _productRepo = productRepo;
        _userRepo = userRepo;
    }

    public override ReviewReadDTO CreateOne(ReviewCreateDTO reviewCreateDto)
    {
        var newReview = _mapper.Map<ReviewCreateDTO, Review>(reviewCreateDto);
        var foundProduct = _productRepo.GetOneById(reviewCreateDto.ProductID);
        var foundUser = _userRepo.GetOneById(reviewCreateDto.UserID);
        if (foundProduct != null && foundUser != null)
        {
          newReview.Product = foundProduct;
          newReview.User = foundUser;
        }
        var result = _repo.CreateOne(newReview);
        return _mapper.Map<Review, ReviewReadDTO>(result);
    }

    public IEnumerable<ReviewReadDTO> GetByProduct(Guid productId)
    {
        var foundProduct = _productRepo.GetOneById(productId);
        if (foundProduct is not null)
        {
          var result = _repo.GetByProduct(productId);
          return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewReadDTO>>(result);
        }
        else
        {
          throw CustomExeption.NotFoundException();
        }
    }
}
