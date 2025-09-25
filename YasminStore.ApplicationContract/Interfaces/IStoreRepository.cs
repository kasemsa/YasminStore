using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Domain.Entities;

namespace YasminStore.ApplicationContract.Interfaces
{
    public interface IStoreRepository
    {

        Task<Store?> GetByIdAsync(int id);
        Task<List<Store>> GetAllAsync();
        Task<Store> AddAsync(Store store);
        Task UpdateAsync(Store store);
        Task DeleteAsync(Store store);


    }
}
