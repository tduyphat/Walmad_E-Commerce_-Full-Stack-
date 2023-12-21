using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Service;

public class CategoryService : BaseService<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO, ICategoryRepo>, ICategoryService
{
  public CategoryService(ICategoryRepo repo, IMapper mapper) : base(repo, mapper)
  {
  }
}
