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

  public IEnumerable<ProductReadDTO> GetAll(GetAllParams options)
  {
    var result = _productRepo.GetAll(options);
    return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductReadDTO>>(result);
  }

  public ProductReadDTO GetOneById(Guid id)
  {
    var result = _productRepo.GetOneById(id);
    return _mapper.Map<Product, ProductReadDTO>(result);
  }

  public ProductReadDTO CreateOne(ProductCreateAndUpdateDTO productCreateAndUpdateDto)
  {
    var result = _productRepo.CreateOne(_mapper.Map<ProductCreateAndUpdateDTO, Product>(productCreateAndUpdateDto));
    return _mapper.Map<Product, ProductReadDTO>(result);
  }

  public ProductReadDTO UpdateOne(Guid id, ProductCreateAndUpdateDTO productCreateAndUpdateDto)
  {
    var result = _productRepo.UpdateOne(id, _mapper.Map<ProductCreateAndUpdateDTO, Product>(productCreateAndUpdateDto));
    return _mapper.Map<Product, ProductReadDTO>(result);
  }

  public bool DeleteOne(Guid id)
  {
    var result = _productRepo.DeleteOne(id);
    return result;
  }
}