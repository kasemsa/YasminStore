using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Product;
using YasminStore.ApplicationContract.Interfaces;

namespace YasminStore.Application.Features.Product.Query.SearchProducts
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, IEnumerable<ProductResponseDto>>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public SearchProductsQueryHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseDto>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repo.SearchAsync(request.Keyword);
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }
    }
}
