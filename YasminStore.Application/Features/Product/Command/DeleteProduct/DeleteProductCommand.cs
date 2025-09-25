using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Application.Features.Product.Command.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest<bool>;
}
