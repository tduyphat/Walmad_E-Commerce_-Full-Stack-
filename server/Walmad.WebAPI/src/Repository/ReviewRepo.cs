using Microsoft.EntityFrameworkCore;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class ReviewRepo : BaseRepo<Review>, IReviewRepo
{
    public ReviewRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public override IEnumerable<Review> GetAll(GetAllParams options)
    {
        return _data.Include("User").Include("Product").Skip(options.Offset).Take(options.Limit).ToArray();
    }

    public IEnumerable<Review> GetByProduct(Guid productId)
    {
        return _data.Where(reviews => reviews.Product.Id == productId);
    }
}
