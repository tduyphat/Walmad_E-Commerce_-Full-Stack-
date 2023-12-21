using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class ProductImageRepo : BaseRepo<ProductImage>, IProductImageRepo
{
    public ProductImageRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}
