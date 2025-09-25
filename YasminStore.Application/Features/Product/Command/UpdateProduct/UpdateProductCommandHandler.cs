using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Product;
using YasminStore.ApplicationContract.Interfaces;

namespace YasminStore.Application.Features.Product.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResponseDto>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ProductResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.Product.Id);
            if (existing == null) throw new Exception("المنتج غير موجود");

            _mapper.Map(request.Product, existing); // تحديث القيم داخل الـ entity
            var updated = await _repo.UpdateAsync(existing);
            return _mapper.Map<ProductResponseDto>(updated);
        }
    }
}
