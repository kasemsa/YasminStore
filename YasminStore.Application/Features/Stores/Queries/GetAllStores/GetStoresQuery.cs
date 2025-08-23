using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Stores;

namespace YasminStore.Application.Features.Stores.Queries.GetAllStores
{
    public record GetStoresQuery() : IRequest<List<StoreResponseDto>>;
}
