using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class AddressRepo : BaseRepo<Address>, IAddressRepo
{
    public AddressRepo(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}
