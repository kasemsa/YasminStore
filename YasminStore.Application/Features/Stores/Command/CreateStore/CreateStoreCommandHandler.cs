using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Application.Features.Stores.Command.CreateStore;
using YasminStore.ApplicationContract.Interfaces;
using YasminStore.Domain.Entities;
using AutoMapper;
using YasminStore.Application.Features.Stores.Commands.CreateStore.Dtos;


namespace YasminStore.Application.Features.Stores.Commands.CreateStore
{


    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, int>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreCommandHandler(
            IStoreRepository storeRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _storeRepository = storeRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = new Store
            {
                Name = request.Name,
                Description = request.Description,
                Location = request.Location,
                CommercialRegistrationNumber = request.CommercialRegistrationNumber,
                OpenAt = request.OpenAt,
                ClosedAt = request.ClosedAt,
                City = request.City,
                saleType = request.SaleType,
                PhoneNumber = request.PhoneNumber,
                logo = request.Logo,
                facebookPage = request.FacebookPage,
                instaAcount = request.InstaAccount,
                whatsapp = request.Whatsapp,
                telegram = request.Telegram,
                StoreCategories = new List<StoreCategory>()
            };

            // Add categories if any
            if (request.CategoryIds.Any())
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    var category = await _categoryRepository.GetByIdAsync(categoryId);
                    if (category != null)
                    {
                        store.StoreCategories.Add(new StoreCategory
                        {
                            CategoryId = categoryId,
                            Store = store
                        });
                    }
                }
            }

            await _storeRepository.AddAsync(store);
            await _unitOfWork.SaveChangesAsync();

            return store.Id;
        }
    }
}

