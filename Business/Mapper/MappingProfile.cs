using AutoMapper;
using Business.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();   

            CreateMap<UserForRegisterDto, User>()
                       .ForMember(dest => dest.PasswordAttemptCount, opt => opt.MapFrom(src => 0))
                       .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UserDetailDto, User>();
            CreateMap<User, UserDetailDto>();

            CreateMap<ShoppingListItemForUpdateDTO, ShoppingListItem>();

            CreateMap<ShoppingListItemForAddDto, ShoppingListItem>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
            .ForMember(dest => dest.ShoppingListId, opt => opt.MapFrom(src => src.ShoppingListId));

        }
    }
}

