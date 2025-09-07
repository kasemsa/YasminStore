using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Product;
using YasminStore.Domain.Entities;

namespace YasminStore.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() { 
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ProductResponseDto>().ReverseMap(); ;
        }
    }
}
