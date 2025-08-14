using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Application.Exceptions;
using YasminStore.ApplicationContract.Interfaces;

namespace YasminStore.Application.Features.Categorys.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            if (category == null) throw new NotFoundException("Category not found");

            await _repository.DeleteAsync(category);
        }

       
    }
}
