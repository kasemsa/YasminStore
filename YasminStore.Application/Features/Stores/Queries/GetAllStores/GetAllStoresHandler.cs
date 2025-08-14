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
   
    public class GetAllStoresHandler : IRequestHandler<GetAllStores, List<StoreDto>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetAllStoresHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<List<StoreDto>> Handle(GetAllStores request, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetAllAsync();
            return _mapper.Map<List<StoreDto>>(stores);
        }
    }
}
