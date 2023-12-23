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
        return _data.Include("User").Include(o => o.OrderProducts).ThenInclude(o => o.Product).Skip(options.Offset).Take(options.Limit).ToArray();
    }

    public override Order? GetOneById(Guid id)
    {
        var allData = _data.Include("User").Include(o => o.OrderProducts).ThenInclude(o => o.Product);
        return allData.FirstOrDefault(order => order.Id == id);
    }

    public IEnumerable<Order> GetByUser(Guid userId)
    {
        return _data.Include("User").Include(o => o.OrderProducts).ThenInclude(o => o.Product).Where(orders => orders.User.Id == userId).ToArray();
    }
}
