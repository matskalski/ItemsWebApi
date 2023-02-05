using ItemsWebService.Domain.Entities;
using ItemsWebService.Domain.Repositories;
using ItemsWebService.Infrastructure.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ItemsWebService.Infrastructure.Repositories
{
    internal class ItemsRepository : IItemsRepository
    {
        private readonly DbSet<Item> _items;
        private readonly WriteAppDbContext _writeDbContext;

        public ItemsRepository(WriteAppDbContext writeDbContext)
        {
            _items = writeDbContext.Items;
            _writeDbContext = writeDbContext;
        }

        public async Task<Item> GetItem(int id)
        {
            return await _items
                .Include("_color")
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id.Value == id);
        }

        public async Task AddItem(Item item)
        {
            await _items.AddAsync(item);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            var item = await GetItem(id);
            _items.Remove(item);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(Item item)
        {
            _items.Update(item);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
