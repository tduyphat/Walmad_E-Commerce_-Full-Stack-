using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Abstraction;

public interface IProductImageService : IBaseService<ProductImage, ProductImageReadDTO, ProductImageCreateDTO, ProductImageUpdateDTO>
{
}
