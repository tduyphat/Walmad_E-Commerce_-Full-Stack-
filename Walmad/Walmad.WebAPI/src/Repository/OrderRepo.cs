using Microsoft.EntityFrameworkCore;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class OrderRepo : BaseRepo<Order>, IOrderRepo
{
    public OrderRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public override IEnumerable<Order> GetAll(GetAllParams options)
    {
        return _data.Include("OrderProducts").Skip(options.Offset).Take(options.Limit).ToArray();
    }
    
    public IEnumerable<Order> GetByUser(Guid userId)
    {
        return _data.Where(orders => orders.User.Id == userId);
    }
}
