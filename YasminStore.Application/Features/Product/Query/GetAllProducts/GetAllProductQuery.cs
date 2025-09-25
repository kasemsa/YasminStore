using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Product;

namespace YasminStore.Application.Features.Product.Query.GetAllProducts
{
    public record GetAllProductQuery() : IRequest<List<ProductResponseDto>>;
}
