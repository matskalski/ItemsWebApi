using ItemsWebService.Application.Services;
using ItemsWebService.Infrastructure.EntityFramework.Contexts;
using ItemsWebService.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemsWebService.Infrastructure.EntityFramework.Services
{
    internal class ItemsService : IItemsService
    {
        private readonly DbSet<ItemReadModel> _items;

        public ItemsService(ReadAppDbContext dbContext)
        {
            _items = dbContext.Items;
        }

        public async Task<bool> ExistisByCode(string name)
        {
            return await _items.AnyAsync(a => a.Name == name);
        }
    }
}
