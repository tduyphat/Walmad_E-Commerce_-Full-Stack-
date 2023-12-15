using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Core.src.Abstraction;

public interface IProductRepo
{
    IEnumerable<Product> GetAll(GetAllParams options);
    Product GetOneById(Guid id);
    Product CreateOne(Product product);
    Product UpdateOne(Guid id, Product product);
    bool DeleteOne(Guid id);
}