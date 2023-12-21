using Microsoft.EntityFrameworkCore;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class ProductRepo : IProductRepo
{
  private DbSet<Product> _products;
  private DatabaseContext _database;

  public ProductRepo(DatabaseContext database)
  {
    _products = database.Products;
    _database = database;
  }

  public Product CreateOne(Product product)
  {
    _products.Add(product);
    _database.SaveChanges();
    return product;
  }

  public bool DeleteOne(Guid id)
  {
    var foundProduct = _products.FirstOrDefault(user => user.Id == id);

    if (foundProduct != null)
    {
      _products.Remove(foundProduct);
      _database.SaveChanges();
      return true;
    }
    else
    {
      return false;
    }
  }

    public bool DeleteOne(Product deleteObject)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAll(GetAllParams options)
  {
    return _products.Skip(options.Offset).Take(options.Limit);
  }

    public IEnumerable<Product> GetByCategory(Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetMostPurchased(int topNumber)
    {
        throw new NotImplementedException();
    }

    public Product GetOneById(Guid id)
  {
    var foundProduct = _products.FirstOrDefault(product => product.Id == id);
    if (foundProduct != null)
    {

      return foundProduct;
    }
    else
    {
      throw new NotImplementedException();
    }
  }

  public Product UpdateOne(Guid id, Product product)
  {
    var foundProduct = _products.FirstOrDefault(product => product.Id == id);
    if (foundProduct != null)
    {

      foundProduct.Title = product.Title;
      foundProduct.Price = product.Price;
      foundProduct.Description = product.Description;
      foundProduct.Category = foundProduct.Category;
      _database.SaveChanges();
      return foundProduct;
    }
    else
    {
      throw new NotImplementedException();
    }
  }

    public Product UpdateOne(Product updateObject)
    {
        throw new NotImplementedException();
    }
}