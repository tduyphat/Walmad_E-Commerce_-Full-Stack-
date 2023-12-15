using Microsoft.EntityFrameworkCore;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class CategoryRepo : ICategoryRepo
{
  private DbSet<Category> _categories;
  private DatabaseContext _database;

  public CategoryRepo(DatabaseContext database)
  {
    _categories = database.Categories;
    _database = database;
  }

  public Category CreateOne(Category category)
  {
    _categories.Add(category);
    _database.SaveChanges();
    return category;
  }

  public bool DeleteOne(Guid id)
  {
    var foundCategory = _categories.FirstOrDefault(category => category.Id == id);

    if (foundCategory != null)
    {
      _categories.Remove(foundCategory);
      _database.SaveChanges();
      return true;
    }
    else
    {
      return false;
    }
  }

  public IEnumerable<Category> GetAll()
  {
    return _categories;
  }

  public Category GetOneById(Guid id)
  {
    var foundCategory = _categories.FirstOrDefault(category => category.Id == id);
    if (foundCategory != null)
    {

      return foundCategory;
    }
    else
    {
      throw new NotImplementedException();
    }
  }

  public Category UpdateOne(Guid id, Category category)
  {
    var foundCategory = _categories.FirstOrDefault(category => category.Id == id);
    if (foundCategory != null)
    {

      foundCategory.Name = category.Name;
      foundCategory.Image = category.Image;
      _database.SaveChanges();
      return foundCategory;
    }
    else
    {
      throw new NotImplementedException();
    }
  }
}