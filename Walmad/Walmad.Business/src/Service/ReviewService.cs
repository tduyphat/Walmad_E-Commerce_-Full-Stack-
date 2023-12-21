using AutoMapper;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Service;

public class ReviewService : BaseService<Review, ReviewReadDTO, ReviewCreateDTO, ReviewUpdateDTO, IReviewRepo>, IReviewService
{
    private IProductRepo _productRepo;

    public ReviewService(IReviewRepo repo, IMapper mapper, IProductRepo productRepo) : base(repo, mapper)
    {
        _productRepo = productRepo;
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
