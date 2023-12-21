using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface ICategoryService : IBaseService<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO>
{
}