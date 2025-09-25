using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Domain.Entities;

namespace YasminStore.ApplicationContract.Interfaces
{
    public interface IProductImageRepository
    {
        Task AddRangeAsync(List<ProductImage> productImages);
        Task<List<ProductImage>> GetAllAsync(int productId);
        Task<ProductImage> AddAsync(ProductImage image);
        Task DeleteAsync(ProductImage image);
    }
}
