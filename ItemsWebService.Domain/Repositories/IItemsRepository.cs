using ItemsWebService.Domain.Entities;

namespace ItemsWebService.Domain.Repositories
{
    public interface IItemsRepository
    {
        public Task<Item> GetItem(int id);
        public Task AddItem(Item item);
        public Task UpdateItem(Item item);
        public Task DeleteItem(int id);
    }
}
