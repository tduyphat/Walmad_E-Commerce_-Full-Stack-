using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Core.src.Abstraction;

public interface ICategoryRepo
{
    IEnumerable<Category> GetAll();
    Category GetOneById(Guid id);
    Category CreateOne(Category category);
    Category UpdateOne(Guid id, Category category);
    bool DeleteOne(Guid id);
}