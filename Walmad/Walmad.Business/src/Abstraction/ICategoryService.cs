using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface ICategoryService
{
    IEnumerable<CategoryReadDTO> GetAll();
    CategoryReadDTO GetOneById(Guid id);
    CategoryReadDTO CreateOne(CategoryCreateAndUpdateDTO categoryCreateAndUpdateDto);
    CategoryReadDTO UpdateOne(Guid id, CategoryCreateAndUpdateDTO categoryCreateAndUpdateDto);
    bool DeleteOne(Guid id);
}