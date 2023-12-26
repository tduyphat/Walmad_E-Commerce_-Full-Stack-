using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Service;

public class ProductImageService : BaseService<ProductImage, ProductImageReadDTO, ProductImageCreateDTO, ProductImageUpdateDTO, IProductImageRepo>, IProductImageService
{
    public ProductImageService(IProductImageRepo repo, IMapper mapper) : base(repo, mapper)
    {
    }
}
