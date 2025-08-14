using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Categories;
using YasminStore.Domain.Entities;


namespace YasminStore.Application.Features.Categorys.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }

        //public List<StoreCategory> StoreCategories { get; set; }
    }


}
