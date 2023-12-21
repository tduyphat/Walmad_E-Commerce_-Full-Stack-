using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src;

public interface IReviewService : IBaseService<Review, ReviewReadDTO, ReviewCreateDTO, ReviewUpdateDTO>
{
    IEnumerable<ReviewReadDTO> GetByProduct(Guid productId);
}
