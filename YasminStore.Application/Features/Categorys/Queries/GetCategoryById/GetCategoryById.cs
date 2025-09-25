using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Categories;

namespace YasminStore.Application.Features.Categorys.Queries.GetCategoryById
{
    public class GetCategoryById : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
    
}
