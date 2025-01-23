using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserWithoutPassword>> GetAllAsync()
        {
            var users = await _dbContext.Users
                .Include(u => u.Roles)
                .ToListAsync();
            
            return users.Select(UserWithoutPassword.FromUser).ToList();
        }
        public async Task<UserWithoutPassword> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Id == id);
                
            return user != null ? UserWithoutPassword.FromUser(user) : null;
        }

        public async Task<User> GetByIdAsyncComplete(int id)
        {
            var user = await _dbContext.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Id == id);
                
            return user;
        }


        public Task<User?> GetByEmailAsync(string email) => 
            _dbContext.Users
                .Include(u => u.Roles)  // Inclui os roles do usuário
                .FirstOrDefaultAsync(u => u.Email == email);
        public async Task<UserWithoutPassword> AddAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return UserWithoutPassword.FromUser(user);
        }
        public async Task<UserWithoutPassword> UpdateAsync(User user)
        {
            var existingUser = _dbContext.Users.Local.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                _dbContext.Entry(existingUser).State = EntityState.Detached;
            }
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return UserWithoutPassword.FromUser(user);
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}