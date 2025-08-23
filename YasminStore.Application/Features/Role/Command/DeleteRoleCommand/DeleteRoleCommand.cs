using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Application.Features.Role.Command.DeleteRoleCommand
{
    public record DeleteRoleCommand(int RoleId) : IRequest<bool>;
}
