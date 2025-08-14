using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Stores;
using YasminStore.ApplicationContract.Interfaces;

namespace YasminStore.Application.Features.Stores.Queries.GetStoreById
{
   
    public class GetStoreByIdQueryHandler : IRequestHandler<GetStoreById, StoreDto>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetStoreByIdQueryHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<StoreDto> Handle(GetStoreById request, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetByIdAsync(request.Id);
            return _mapper.Map<StoreDto>(store);
        }
    }
}
