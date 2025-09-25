using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Application.Features.Stores.Command.UpdateStore;
using YasminStore.ApplicationContract.Interfaces;
using YasminStore.Domain.Entities;

namespace YasminStore.Application.Features.Stores.Command.UpdateStore
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Unit>
    {
        private readonly IStoreRepository _repo;
        private readonly IMapper _mapper;

        public UpdateStoreCommandHandler(IStoreRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = await _repo.GetByIdAsync(request.Dto.Id);
            if (store is null) throw new KeyNotFoundException("Store not found");

            _mapper.Map(request.Dto, store);

            if (request.Dto.CategoryIds != null)
            {
                store.StoreCategories.Clear();
                store.StoreCategories.AddRange(
                    request.Dto.CategoryIds.Distinct().Select(cid => new StoreCategory
                    {
                        StoreId = store.Id,
                        CategoryId = cid
                    })
                );
            }

            await _repo.UpdateAsync(store);
            return Unit.Value;
        }
    }
}   
