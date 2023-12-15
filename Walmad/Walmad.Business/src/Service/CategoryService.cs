using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Service;

public class CategoryService : ICategoryService
{
  private ICategoryRepo _categoryRepo;
  private IMapper _mapper;

  public CategoryService(ICategoryRepo categoryRepo, IMapper mapper)
  {
    _categoryRepo = categoryRepo;
    _mapper = mapper;
  }

  public IEnumerable<Category> GetAll()
  {
    var result = _categoryRepo.GetAll();
    return result;
  }

  public Category GetOneById(Guid id)
  {
    var result = _categoryRepo.GetOneById(id);
    return result;
  }

  public Category CreateOne(CategoryCreateAndUpdateDTO categoryCreateAndUpdateDto)
  {
    var result = _categoryRepo.CreateOne(_mapper.Map<CategoryCreateAndUpdateDTO, Category>(categoryCreateAndUpdateDto));
    return result;
  }

  public Category UpdateOne(Guid id, CategoryCreateAndUpdateDTO categoryCreateAndUpdateDto)
  {
    var result = _categoryRepo.UpdateOne(id, _mapper.Map<CategoryCreateAndUpdateDTO, Category>(categoryCreateAndUpdateDto));
    return result;
  }

  public bool DeleteOne(Guid id)
  {
    var result = _categoryRepo.DeleteOne(id);
    return result;
  }
}
