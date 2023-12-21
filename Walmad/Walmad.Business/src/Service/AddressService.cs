using AutoMapper;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Service;

public class AddressService : BaseService<Address, AddressReadDTO, AddressCreateDTO, AddressUpdateDTO, IAddressRepo>, IAddressService
{
    public AddressService(IAddressRepo repo, IMapper mapper) : base(repo, mapper)
    {
    }
}
