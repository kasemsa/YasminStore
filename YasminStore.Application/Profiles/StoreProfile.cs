using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using YasminStore.ApplicationContract.DTOs.Stores;
using YasminStore.Domain.Entities;

namespace YasminStore.Application.Profiles
{
   

    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<CreateStoreDto, Store>();
        }
    }
}
