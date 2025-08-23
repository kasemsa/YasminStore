using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Stores;

namespace YasminStore.Application.Features.Stores.Command.UpdateStore
{
    public record UpdateStoreCommand(UpdateStoreDto Dto) : IRequest<Unit>;
}
