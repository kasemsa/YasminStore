using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Role;
using YasminStore.ApplicationContract.Interfaces;

namespace YasminStore.Application.Features.Role.Command.UpdateRoleCommand
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RoleResponseDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleResponseDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var existing = await _roleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existing == null) return null;

            _mapper.Map(request.RoleDto, existing); // يحدّث الخصائص من DTO على الكائن الحالي
            var updated = await _roleRepository.UpdateAsync(existing, cancellationToken);

            return _mapper.Map<RoleResponseDto>(updated);
        }
    }
}
