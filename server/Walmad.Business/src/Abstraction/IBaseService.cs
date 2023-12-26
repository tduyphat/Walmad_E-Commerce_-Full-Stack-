using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Abstraction;

public interface IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO> where T : BaseEntity
{
    IEnumerable<TReadDTO> GetAll(GetAllParams options);
    TReadDTO GetOneById(Guid id);
    TReadDTO CreateOne(TCreateDTO createObject);
    TReadDTO UpdateOne(Guid id, TUpdateDTO updateObject);
    bool DeleteOne(Guid id);
}
