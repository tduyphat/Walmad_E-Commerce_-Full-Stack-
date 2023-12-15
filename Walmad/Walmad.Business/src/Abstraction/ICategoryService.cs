using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface ICategoryService
{
    IEnumerable<Category> GetAll();
    Category GetOneById(Guid id);
    Category CreateOne(CategoryCreateAndUpdateDTO categoryCreateAndUpdateDto);
    Category UpdateOne(Guid id, CategoryCreateAndUpdateDTO categoryCreateAndUpdateDto);
    bool DeleteOne(Guid id);
}