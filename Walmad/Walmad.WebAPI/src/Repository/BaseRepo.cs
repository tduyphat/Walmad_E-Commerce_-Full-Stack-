using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
{
  protected readonly DbSet<T> _data;
  protected readonly DatabaseContext _databaseContext;

  public BaseRepo(DatabaseContext databaseContext)
  {
    _databaseContext = databaseContext;
    _data = _databaseContext.Set<T>();
  }

  public virtual T CreateOne(T createObject)
  {
    _data.Add(createObject);
    _databaseContext.SaveChanges();
    return createObject;
  }

  public virtual bool DeleteOne(T deleteObject)
  {
    _data.Remove(deleteObject);
    _databaseContext.SaveChanges();
    return true;
  }

  public virtual IEnumerable<T> GetAll(GetAllParams options)
  {
    return _data.Skip(options.Offset).Take(options.Limit).ToArray();
  }

  public virtual T? GetOneById(Guid id)
  {
    return _data.Find(id);
  }

  public virtual T UpdateOne(T updateObject)
  {
    _data.Update(updateObject);
    _databaseContext.SaveChanges();
    return updateObject;
  }
}
