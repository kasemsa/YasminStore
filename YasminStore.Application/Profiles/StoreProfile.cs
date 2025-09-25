using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Application.Features.Stores.Commands.CreateStore.Dtos;
using YasminStore.ApplicationContract.DTOs.Stores;
using YasminStore.Domain.Entities;

namespace YasminStore.Application.Profiles
{
   

    public class StoreMappingProfile : Profile
{
    public StoreMappingProfile()
    {
        // Entity -> Response DTO
        CreateMap<Store, StoreResponseDto>()
            .ForMember(dest => dest.CategoryIds, opt => opt.MapFrom(src =>
                src.StoreCategories.Select(sc => sc.CategoryId).ToList()))
            .ForMember(dest => dest.StoreImages, opt => opt.MapFrom(src => src.StoreImages));

        CreateMap<StoreImages, StoreImageDto>();

            CreateMap<StoreCategory, StoreCategory>();

        // Create DTO -> Entity
        CreateMap<CreateStoreDto, Store>()
            .ForMember(dest => dest.StoreCategories, opt => opt.Ignore()) // يتم تعيينها في Handler
            .ForMember(dest => dest.StoreImages, opt => opt.Ignore()); // يتم تعيينها في Handler إذا لزم

        // Update DTO -> Entity
        CreateMap<UpdateStoreDto, Store>()
            .ForMember(dest => dest.StoreCategories, opt => opt.Ignore())
            .ForMember(dest => dest.StoreImages, opt => opt.Ignore());
    }
}
}
