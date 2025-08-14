using YasminStore.ApplicationContract.Interfaces;
using YasminStore.Domain.Entities;
using YasminStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace YasminStore.Infrastructure.Repositories
{
    public class StoreRepository :  IStoreRepository
    {
        private readonly YasminStoreDbContext _context;

        public StoreRepository(YasminStoreDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return store.Id;
        }

        public async Task<List<Store>> GetAllAsync()
        {
            return await _context.Stores.ToListAsync();
        }

       

        public async Task<Store?> GetByIdAsync(int id)
        {
            return await _context.Stores.FindAsync(id);
        }

       
    }
}
