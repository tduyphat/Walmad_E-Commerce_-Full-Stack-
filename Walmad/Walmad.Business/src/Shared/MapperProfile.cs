using AutoMapper;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Shared;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserReadDTO>();
        CreateMap<UserCreateDTO, User>();
        CreateMap<UserUpdateDTO, User>();
        CreateMap<CategoryCreateAndUpdateDTO, Category>();
        CreateMap<ProductCreateAndUpdateDTO, Product>();
    }
}
