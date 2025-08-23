using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Stores;
using YasminStore.ApplicationContract.Interfaces;

namespace YasminStore.Application.Features.Stores.Queries.GetAllStores
{

    public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, List<StoreResponseDto>>
    {
        private readonly IStoreRepository _repo;
        private readonly IMapper _mapper;

        public GetStoresQueryHandler(IStoreRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<StoreResponseDto>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<List<StoreResponseDto>>(list);
        }
    }
}
