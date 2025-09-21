using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Product;
using YasminStore.ApplicationContract.Interfaces;
using YasminStore.ApplicationContract.ServicesInterfaces;
using YasminStore.Domain.Entities;

namespace YasminStore.Application.Features.Product.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IProductImageRepository _productImageRepository;
        public CreateProductHandler(IProductRepository repo, IMapper mapper, IFileService fileService, IProductImageRepository productImageRepository)
        {
            _repo = repo;
            _mapper = mapper;
            _fileService = fileService;
            _productImageRepository = productImageRepository;   
        }

        public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var Product = _mapper.Map<Domain.Entities.Product>(request.Product);

            Product.MainImageUrl = await _fileService.SaveFileAndGetPath(request.Product.ImageUrl);
            
            var created = await _repo.AddAsync(Product);

            foreach (var image in request.Product.ProductImages)
            {
                var productImage = new ProductImage()
                {
                    Image = await _fileService.SaveFileAndGetPath(image),
                    ProductId = created.Id
                };

                await _productImageRepository.AddAsync(productImage);
            }

            return _mapper.Map<ProductResponseDto>(created);
        }
    }
}
