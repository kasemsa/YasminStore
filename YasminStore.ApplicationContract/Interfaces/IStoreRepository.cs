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

        Task<int> AddAsync(Store store);

        Task<List<Store>> GetAllAsync();
        Task<Store?> GetByIdAsync(int id);
       
      
    }
}
