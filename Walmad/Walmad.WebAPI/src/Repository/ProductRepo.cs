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
        var allData = _data.Include("Images").Include("Category").Skip(options.Offset).Take(options.Limit);
        if (options.sortType == SortType.byTitle && options.sortOrder == SortOrder.asc)
        {
            return allData.OrderBy(item => item.Title).ToArray();
        }
        if (options.sortType == SortType.byTitle && options.sortOrder == SortOrder.desc)
        {
            return allData.OrderByDescending(item => item.Title).ToArray();
        }
        if (options.sortType == SortType.byPrice && options.sortOrder == SortOrder.asc)
        {
            return allData.OrderBy(item => item.Price).ToArray();
        }
        return allData.OrderByDescending(item => item.Price).ToArray();
    }

    public override Product? GetOneById(Guid id)
    {
        var allData = _data.Include("Images").Include("Category");
        return allData.FirstOrDefault(product => product.Id == id);
    }

    public IEnumerable<Product> GetByCategory(Guid categoryId)
    {
        return _data.Include("Images").Include("Category").Where(products => products.Category.Id == categoryId);
    }

    public IEnumerable<Product> GetMostPurchased(int topNumber)
    {
        throw new NotImplementedException();
    }
}