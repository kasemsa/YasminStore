using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Application.Features.Stores.Command.CreateStore;
using YasminStore.Application.Features.Stores.Commands.CreateStore.Dtos;
using YasminStore.ApplicationContract.DTOs.Stores;
using YasminStore.ApplicationContract.Interfaces;
using YasminStore.Domain.Entities;


namespace YasminStore.Application.Features.Stores.Commands.CreateStore
{


    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, StoreResponseDto>
    {
        private readonly IStoreRepository _repo;
        private readonly IMapper _mapper;

        public CreateStoreCommandHandler(IStoreRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<StoreResponseDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Store>(request.Dto);

            if (request.Dto.CategoryIds?.Count > 0)
            {
                entity.StoreCategories = request.Dto.CategoryIds
                    .Distinct()
                    .Select(cid => new StoreCategory { CategoryId = cid, Store = entity })
                    .ToList();
            }

            var created = await _repo.AddAsync(entity);
            return _mapper.Map<StoreResponseDto>(created);
        }
    }
}

