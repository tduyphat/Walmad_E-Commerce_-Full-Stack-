using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Service;

public class ProductService : BaseService<Product, ProductReadDTO, ProductCreateDTO, ProductUpdateDTO, IProductRepo>, IProductService
{
    private ICategoryRepo _categoryRepo;

    public ProductService(IProductRepo repo, IMapper mapper, ICategoryRepo categoryRepo) : base(repo, mapper)
    {
      _categoryRepo = categoryRepo;
    }

    public override ProductReadDTO CreateOne(ProductCreateDTO productCreateDto)
    {
        var foundCategory = _categoryRepo.GetOneById(productCreateDto.categoryId);
        if (foundCategory is not null)
        {
          var newProduct = _mapper.Map<ProductCreateDTO, Product>(productCreateDto);
          newProduct.Category = foundCategory;
          var result = _repo.CreateOne(newProduct);
          return _mapper.Map<Product, ProductReadDTO>(result);
        }
        else
        {
          throw CustomExeption.NotFoundException();
        }
    }

    public override ProductReadDTO UpdateOne(Guid id, ProductUpdateDTO productUpdateDto)
    {
        var foundCategory = _categoryRepo.GetOneById(productUpdateDto.categoryId);
        if (foundCategory is not null)
        {
          var updateProduct = _mapper.Map<ProductUpdateDTO, Product>(productUpdateDto);
          updateProduct.Category = foundCategory;
          var result = _repo.UpdateOne(updateProduct);
          return _mapper.Map<Product, ProductReadDTO>(result);
        }
        else
        {
          throw CustomExeption.NotFoundException();
        }
    }

    public IEnumerable<ProductReadDTO> GetByCategory(Guid categoryId)
    {
        var foundCategory = _categoryRepo.GetOneById(categoryId);
        if (foundCategory is not null)
        {
          var result = _repo.GetByCategory(categoryId);
          return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductReadDTO>>(result);
        }
        else
        {
          throw CustomExeption.NotFoundException();
        }
    }

    public IEnumerable<ProductReadDTO> GetMostPurchased(int topNumber)
    {
        var result = _repo.GetMostPurchased(topNumber);
        return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductReadDTO>>(result);
    }
}