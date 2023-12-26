using Walmad.Core.src.Entity;

namespace Walmad.Core.src.Abstraction;

public interface IReviewRepo : IBaseRepo<Review>
{
    IEnumerable<Review> GetByProduct(Guid productId);
}
