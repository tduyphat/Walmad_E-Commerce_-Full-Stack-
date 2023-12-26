using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
{
    public CategoryRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}