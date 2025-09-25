using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Role;

namespace YasminStore.Application.Features.Role.Command.CreateRoleCommand
{

    public record CreateRoleCommand(CreateRoleDto RoleDto) : IRequest<RoleResponseDto>;

}
