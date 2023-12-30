using Microsoft.EntityFrameworkCore;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class OrderRepo : BaseRepo<Order>, IOrderRepo
{
    private DbSet<Product> _products;
    public OrderRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
        _products = databaseContext.Products;
    }

    public override Order CreateOne(Order order)
    {
        using ( var transaction = _databaseContext.Database.BeginTransaction())
        {
            try
            {
                foreach(var orderProduct in order.OrderProducts)
                {
                    var foundProduct = _products.First(product => product == orderProduct.Product);
                    if (foundProduct.Inventory >= orderProduct.Quantity)
                    {
                        Console.WriteLine($"BEFORE ____ {foundProduct.Inventory}");
                        foundProduct.Inventory -= orderProduct.Quantity;
                        Console.WriteLine($"AFTER ____ {foundProduct.Inventory}");
                        _products.Update(foundProduct);
                        _databaseContext.SaveChanges();
                    }
                    else
                    {
                        throw CustomExeption.BadRequestException("Product out of inventory");
                    }
                }
                _data.Add(order);
                _databaseContext.SaveChanges();
                transaction.Commit();
                return order;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
                throw;
            }
        }
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
