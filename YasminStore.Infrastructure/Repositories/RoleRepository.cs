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
    public class RoleRepository : IRoleRepository
    {
        private readonly YasminStoreDbContext _context;

        public RoleRepository(YasminStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Role> AddAsync(Role role, CancellationToken cancellationToken)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync(cancellationToken);
            return role;
        }

        public async Task<Role?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Roles.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<List<Role>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Roles.ToListAsync(cancellationToken);
        }

        public async Task<Role> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync(cancellationToken);
            return role;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FindAsync(new object[] { id }, cancellationToken);
            if (role == null) return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }

}
