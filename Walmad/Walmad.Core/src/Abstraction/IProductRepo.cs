using Walmad.Core.src.Entity;

namespace Walmad.Core.src.Abstraction;

public interface IProductRepo : IBaseRepo<Product>
{
    IEnumerable<Product> GetByCategory(Guid categoryId);
    IEnumerable<Product> GetMostPurchased(int topNumber);
}