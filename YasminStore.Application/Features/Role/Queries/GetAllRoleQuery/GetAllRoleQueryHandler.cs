using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Role;
using YasminStore.ApplicationContract.Interfaces;

namespace YasminStore.Application.Features.Role.Queries.GetAllRoleQuery
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRoleQuery, List<RoleResponseDto>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleResponseDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<RoleResponseDto>>(roles);
        }
    }
}
