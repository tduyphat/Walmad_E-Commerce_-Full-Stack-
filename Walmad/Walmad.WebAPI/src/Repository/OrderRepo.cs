using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class OrderRepo : BaseRepo<Order>, IOrderRepo
{
    public OrderRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public IEnumerable<Order> GetByUser(Guid userId)
    {
        throw new NotImplementedException();
    }
}
