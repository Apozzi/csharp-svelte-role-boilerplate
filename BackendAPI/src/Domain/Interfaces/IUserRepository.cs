using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserWithoutPassword>> GetAllAsync();
        Task<UserWithoutPassword> GetByIdAsync(int id);
        Task<User> GetByIdAsyncComplete(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<UserWithoutPassword> AddAsync(User user);
        Task<UserWithoutPassword> UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}