using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.Interfaces;

namespace YasminStore.Application.Features.Stores.Command.DeleteStore
{
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, Unit>
    {
        private readonly IStoreRepository _repo;

        public DeleteStoreCommandHandler(IStoreRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var store = await _repo.GetByIdAsync(request.Id);
            if (store is null) return Unit.Value;

            await _repo.DeleteAsync(store);
            return Unit.Value;
        }
    }
}
