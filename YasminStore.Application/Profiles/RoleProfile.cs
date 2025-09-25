using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Application.Features.Categorys.Command.UpdateCategory;
using YasminStore.Application.Features.Role.Command.UpdateRoleCommand;
using YasminStore.ApplicationContract.DTOs.Categories;
using YasminStore.ApplicationContract.DTOs.Role;
using YasminStore.Domain.Entities;

namespace YasminStore.Application.Profiles
{
   

    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRoleDto, Role>();
            CreateMap<UpdateRoleDto, Role>();
            CreateMap<Role, RoleResponseDto>();
        }
    }
}
