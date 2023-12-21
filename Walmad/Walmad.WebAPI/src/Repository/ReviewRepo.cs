using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class ReviewRepo : BaseRepo<Review>, IReviewRepo
{
    public ReviewRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public IEnumerable<Review> GetByProduct(Guid productId)
    {
        return _data.Where(reviews => reviews.Product.Id == productId);
    }
}
