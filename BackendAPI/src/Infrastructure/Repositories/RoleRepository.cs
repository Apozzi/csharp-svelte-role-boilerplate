using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _dbContext;

        public RoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Role>> GetAllAsync() => _dbContext.Roles.ToListAsync();
        public Task<Role> GetByIdAsync(int id) => _dbContext.Roles.FindAsync(id).AsTask();
        public async Task<Role> AddAsync(Role Role)
        {
            _dbContext.Roles.Add(Role);
            await _dbContext.SaveChangesAsync();
            return Role;
        }
        public async Task<Role> UpdateAsync(Role role)
        {
            var existingRole = _dbContext.Roles.Local.FirstOrDefault(r => r.Id == role.Id);
            if (existingRole != null)
            {
                _dbContext.Entry(existingRole).State = EntityState.Detached;
            }
            _dbContext.Roles.Update(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }
        public async Task DeleteAsync(int id)
        {
            var Role = await GetByIdAsync(id);
            _dbContext.Roles.Remove(Role);
            await _dbContext.SaveChangesAsync();
        }
    }
}