using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.Interfaces;
using YasminStore.Domain.Entities;
using YasminStore.Persistence;

namespace YasminStore.Infrastructure.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly YasminStoreDbContext _context;

        public ProductImageRepository(YasminStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<ProductImage> productImages)
        {
            await _context.ProductImages.AddRangeAsync(productImages);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductImage>> GetAllAsync(int productId)
        {
            return await _context.ProductImages
                .Include(pi => pi.Product)
                .Where(pi => pi.ProductId == productId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductImage> AddAsync(ProductImage image)
        {
            await _context.ProductImages.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task DeleteAsync(ProductImage image)
        {
            _context.ProductImages.Remove(image);
            await _context.SaveChangesAsync();
        }

        // Additional helpful methods that might be useful
        public async Task<List<ProductImage>> GetByProductIdAsync(int productId)
        {
            return await _context.ProductImages
                .Where(pi => pi.ProductId == productId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductImage?> GetByIdAsync(int id)
        {
            return await _context.ProductImages
                .Include(pi => pi.Product)
                .FirstOrDefaultAsync(pi => pi.Id == id);
        }

        public async Task UpdateAsync(ProductImage image)
        {
            _context.ProductImages.Update(image);
            await _context.SaveChangesAsync();
        }
    }
}
