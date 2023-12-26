using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Core.src.Abstraction;

public interface IBaseRepo<T> where T : BaseEntity
{
    IEnumerable<T> GetAll(GetAllParams options);
    T? GetOneById(Guid id);
    T CreateOne(T createObject);
    T UpdateOne(T updateObject);
    bool DeleteOne(T deleteObject);
}
