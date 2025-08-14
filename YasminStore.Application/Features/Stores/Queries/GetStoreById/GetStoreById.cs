using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Stores;

namespace YasminStore.Application.Features.Stores.Queries.GetStoreById
{
   

    public class GetStoreById : IRequest<StoreDto>
    {
        public int Id { get; set; }
    }
}
