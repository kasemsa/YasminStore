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

    public class GetStoreByIdQueryHandler : IRequestHandler<GetStoreByIdQuery, StoreResponseDto>
    {
        private readonly IStoreRepository _repo;
        private readonly IMapper _mapper;

        public GetStoreByIdQueryHandler(IStoreRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<StoreResponseDto> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var store = await _repo.GetByIdAsync(request.Id);
            if (store is null) throw new KeyNotFoundException("Store not found");
            return _mapper.Map<StoreResponseDto>(store);
        }
    }
}
