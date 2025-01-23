using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(int id);
        Task<Item> AddAsync(Item item);
        Task<Item> UpdateAsync(Item item);
        Task DeleteAsync(int id);
    }
}