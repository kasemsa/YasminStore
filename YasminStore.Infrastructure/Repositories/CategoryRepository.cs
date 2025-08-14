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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly YasminStoreDbContext _context;

        public CategoryRepository(YasminStoreDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Category category)
        {
           _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }
       
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
