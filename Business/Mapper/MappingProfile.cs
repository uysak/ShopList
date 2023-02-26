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

            CreateMap<UserForRegisterDto, User>()
                       .ForMember(dest => dest.PasswordAttemptCount, opt => opt.MapFrom(src => 0))
                       .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => DateTime.Now));


        }
    }
}

