using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Abstraction;

public interface IProductService : IBaseService<Product, ProductReadDTO, ProductCreateDTO, ProductUpdateDTO>
{
    IEnumerable<ProductReadDTO> GetByCategory(Guid categoryId);
    IEnumerable<ProductReadDTO> GetMostPurchased(int topNumber);
}