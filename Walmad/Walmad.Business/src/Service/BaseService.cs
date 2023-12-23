using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;

namespace Walmad.Business.src.Service;

public class BaseService<T, TReadDTO, TCreateDTO, TUpdateDTO, TRepo> : IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>
where T : BaseEntity
where TRepo : IBaseRepo<T>
{
    protected readonly TRepo _repo;
    protected IMapper _mapper;

    public BaseService(TRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public virtual TReadDTO CreateOne(TCreateDTO createObject)
    {
        var result = _repo.CreateOne(_mapper.Map<TCreateDTO, T>(createObject));
        return _mapper.Map<T, TReadDTO>(result);
    }

    public virtual bool DeleteOne(Guid id)
    {
        var foundItem = _repo.GetOneById(id);
        if (foundItem is not null)
        {
            return _repo.DeleteOne(foundItem);
        }
        else
        {
            throw CustomExeption.NotFoundException("Id not found");
        }
    }

    public virtual IEnumerable<TReadDTO> GetAll(GetAllParams options)
    {
        return _mapper.Map<IEnumerable<T>, IEnumerable<TReadDTO>>(_repo.GetAll(options));
    }

    public virtual TReadDTO GetOneById(Guid id)
    {
        var result = _repo.GetOneById(id);
        if (result is not null)
        {
            return _mapper.Map<T, TReadDTO>(result);
        }
        else
        {
            throw CustomExeption.NotFoundException("Id not found");
        }
    }

    public virtual TReadDTO UpdateOne(Guid id, TUpdateDTO updateObject)
    {
        var foundItem = _repo.GetOneById(id);
        if (foundItem is not null)
        {
            var result = _repo.UpdateOne(_mapper.Map(updateObject, foundItem));
            return _mapper.Map<T, TReadDTO>(result);
        }
        else
        {
            throw CustomExeption.NotFoundException("Id not found");
        }
    }
}
