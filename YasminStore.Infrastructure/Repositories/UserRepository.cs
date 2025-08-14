using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Domain.Entities;
using YasminStore.ApplicationContract.Interfaces;

namespace YasminStore.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
