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

  public IEnumerable<CategoryReadDTO> GetAll()
  {
    var result = _categoryRepo.GetAll();
    return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryReadDTO>>(result);
  }

  public CategoryReadDTO GetOneById(Guid id)
  {
    var result = _categoryRepo.GetOneById(id);
    return _mapper.Map<Category, CategoryReadDTO>(result);
  }

  public CategoryReadDTO CreateOne(CategoryCreateAndUpdateDTO categoryCreateAndUpdateDto)
  {
    var result = _categoryRepo.CreateOne(_mapper.Map<CategoryCreateAndUpdateDTO, Category>(categoryCreateAndUpdateDto));
    return _mapper.Map<Category, CategoryReadDTO>(result);
  }

  public CategoryReadDTO UpdateOne(Guid id, CategoryCreateAndUpdateDTO categoryCreateAndUpdateDto)
  {
    var result = _categoryRepo.UpdateOne(id, _mapper.Map<CategoryCreateAndUpdateDTO, Category>(categoryCreateAndUpdateDto));
    return _mapper.Map<Category, CategoryReadDTO>(result);
  }

  public bool DeleteOne(Guid id)
  {
    var result = _categoryRepo.DeleteOne(id);
    return result;
  }
}
