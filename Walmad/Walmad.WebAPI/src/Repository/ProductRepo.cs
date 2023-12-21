using Microsoft.EntityFrameworkCore;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class ProductRepo : BaseRepo<Product>, IProductRepo
{
    public ProductRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public override IEnumerable<Product> GetAll(GetAllParams options)
    {
        return _data.Include("ProductImages").Skip(options.Offset).Take(options.Limit).ToArray();
    }

    public IEnumerable<Product> GetByCategory(Guid categoryId)
    {
        return _data.Where(products => products.Category.Id == categoryId);
    }

    public IEnumerable<Product> GetMostPurchased(int topNumber)
    {
        throw new NotImplementedException();
    }
}