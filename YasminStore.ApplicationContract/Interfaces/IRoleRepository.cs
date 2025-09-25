using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Domain.Entities;

namespace YasminStore.ApplicationContract.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> AddAsync(Role role, CancellationToken cancellationToken);
        Task<Role?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Role>> GetAllAsync(CancellationToken cancellationToken);
        Task<Role> UpdateAsync(Role role, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
