using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface IProductService
{
    IEnumerable<ProductReadDTO> GetAll(GetAllParams options);
    ProductReadDTO GetOneById(Guid id);
    ProductReadDTO CreateOne(ProductCreateAndUpdateDTO productCreateAndUpdateDto);
    ProductReadDTO UpdateOne(Guid id, ProductCreateAndUpdateDTO productCreateAndUpdateDto);
    bool DeleteOne(Guid id);
}