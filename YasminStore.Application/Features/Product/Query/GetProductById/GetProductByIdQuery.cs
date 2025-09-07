using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Product;

namespace YasminStore.Application.Features.Product.Query.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductResponseDto>;
}
