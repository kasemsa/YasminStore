using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Application.Features.Stores.Command.DeleteStore
{
    public record DeleteStoreCommand(int Id) : IRequest<Unit>;
}
