using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Abstraction;

public interface IAddressService : IBaseService<Address, AddressReadDTO, AddressCreateDTO, AddressUpdateDTO>
{
}
