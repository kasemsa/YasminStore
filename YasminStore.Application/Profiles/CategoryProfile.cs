using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Application.Features.Categorys.Command.UpdateCategory;
using YasminStore.ApplicationContract.DTOs.Categories;
using YasminStore.Domain.Entities;

namespace YasminStore.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, UpdateCategoryCommand>();
        }
    }
}
