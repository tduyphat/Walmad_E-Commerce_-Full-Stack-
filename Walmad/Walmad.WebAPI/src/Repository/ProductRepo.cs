using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class ProductRepo : BaseRepo<Product>, IProductRepo
{
    public ProductRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public IEnumerable<Product> GetByCategory(Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetMostPurchased(int topNumber)
    {
        throw new NotImplementedException();
    }
}