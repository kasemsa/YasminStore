using Microsoft.EntityFrameworkCore;
using System;
using YasminStore.ApplicationContract.Interfaces;
using YasminStore.Domain.Entities;
using YasminStore.Persistence;

namespace YasminStore.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly YasminStoreDbContext _context;

        public StoreRepository(YasminStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Store?> GetByIdAsync(int id)
        {
            return await _context.Stores
                .Include(s => s.StoreImages)
                .Include(s => s.StoreCategories)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Store>> GetAllAsync()
        {
            return await _context.Stores
                .Include(s => s.StoreImages)
                .Include(s => s.StoreCategories)
                .ToListAsync();
        }

        public async Task<Store> AddAsync(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task UpdateAsync(Store store)
        {
            _context.Stores.Update(store);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Store store)
        {
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
        }
    }
}
