using AutoMapper;
using Walmad.Business.src.DTO;
using Walmad.Core.src.Entity;

namespace Walmad.Business.src.Shared;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserReadDTO>()
        // .ForMember(
        //     dest => dest.Addresses,
        //     map => map.MapFrom(source => source.Addresses as IEnumerable<AddressReadDTO>)
        // )
        ;
        CreateMap<UserCreateDTO, User>()
        // .ForMember(
        //     dest => dest.Addresses,
        //     map => map.MapFrom(source => source.Addresses as IEnumerable<Address>)
        // )
        ;
        CreateMap<UserUpdateDTO, User>();

        CreateMap<Address, AddressReadDTO>();
        CreateMap<AddressCreateDTO, Address>();
        CreateMap<AddressCreateDTO, Address>();

        CreateMap<Category, CategoryReadDTO>();
        CreateMap<CategoryCreateDTO, Category>();
        CreateMap<CategoryUpdateDTO, Category>();

        CreateMap<Product, ProductReadDTO>();
        CreateMap<ProductCreateDTO, Product>();
        CreateMap<ProductUpdateDTO, Product>();

        CreateMap<ProductImage, ProductImageReadDTO>();
        CreateMap<ProductImageCreateDTO, ProductImage>();
        CreateMap<ProductImageUpdateDTO, ProductImage>();

        CreateMap<Review, ReviewReadDTO>();
        CreateMap<ReviewCreateDTO, Review>();
        CreateMap<ReviewUpdateDTO, Review>();

        CreateMap<Order, OrderReadDTO>();
        CreateMap<OrderCreateDTO, Order>();
        CreateMap<OrderUpdateDTO, Order>();
    }
}
