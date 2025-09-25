using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Application.Features.Stores.Command.CreateStore;
using YasminStore.ApplicationContract.Interfaces;
using YasminStore.Domain.Entities;

namespace YasminStore.Application.Features.Categorys.Command.CreateCategory
{

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name
            };
            await _categoryRepository.AddAsync(category);
            return category.Id;
        }
    }
}
