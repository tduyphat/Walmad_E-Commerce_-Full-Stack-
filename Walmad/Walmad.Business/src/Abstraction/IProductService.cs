using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface IProductService
{
    IEnumerable<Product> GetAll(GetAllParams options);
    Product GetOneById(Guid id);
    Product CreateOne(ProductCreateAndUpdateDTO productCreateAndUpdateDto);
    Product UpdateOne(Guid id, ProductCreateAndUpdateDTO productCreateAndUpdateDto);
    bool DeleteOne(Guid id);
}