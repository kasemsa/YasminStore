using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Application.Features.Stores.Commands.CreateStore.Dtos;
using YasminStore.ApplicationContract.DTOs;
using YasminStore.ApplicationContract.DTOs.Stores;
using YasminStore.Domain.Entities;
using YasminStore.Domain.Enums;

namespace YasminStore.Application.Features.Stores.Command.CreateStore
{



    public record CreateStoreCommand(CreateStoreDto Dto) : IRequest<StoreResponseDto>;

}
