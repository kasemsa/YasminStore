using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Product;
using YasminStore.ApplicationContract.Interfaces;

namespace YasminStore.Application.Features.Product.Query.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductQuery, List<ProductResponseDto>>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public GetAllProductsHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<List<ProductResponseDto>>(products);
        }
    }
}
