using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Service;

public class ProductService : IProductService
{
  private IProductRepo _productRepo;
  private IMapper _mapper;

  public ProductService(IProductRepo productRepo, IMapper mapper)
  {
    _productRepo = productRepo;
    _mapper = mapper;
  }

  public IEnumerable<Product> GetAll(GetAllParams options)
  {
    var result = _productRepo.GetAll(options);
    return result;
  }

  public Product GetOneById(Guid id)
  {
    var result = _productRepo.GetOneById(id);
    return result;
  }

  public Product CreateOne(ProductCreateAndUpdateDTO productCreateAndUpdateDto)
  {
    var result = _productRepo.CreateOne(_mapper.Map<ProductCreateAndUpdateDTO, Product>(productCreateAndUpdateDto));
    return result;
  }

  public Product UpdateOne(Guid id, ProductCreateAndUpdateDTO productCreateAndUpdateDto)
  {
    var result = _productRepo.UpdateOne(id, _mapper.Map<ProductCreateAndUpdateDTO, Product>(productCreateAndUpdateDto));
    return result;
  }

  public bool DeleteOne(Guid id)
  {
    var result = _productRepo.DeleteOne(id);
    return result;
  }
}