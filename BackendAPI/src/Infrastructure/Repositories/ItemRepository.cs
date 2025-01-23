using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _dbContext;

        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Item>> GetAllAsync() => _dbContext.Items.ToListAsync();
        public Task<Item> GetByIdAsync(int id) => _dbContext.Items.FindAsync(id).AsTask();
        public async Task<Item> AddAsync(Item item)
        {
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }
        public async Task<Item> UpdateAsync(Item item)
        {
            var existingItem = _dbContext.Items.Local.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                _dbContext.Entry(existingItem).State = EntityState.Detached;
            }

            _dbContext.Items.Update(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }
        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            _dbContext.Items.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}