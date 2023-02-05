using ItemsWebService.Domain.Entities;

namespace ItemsWebService.Domain.Repositories
{
    public interface IColorsRepository
    {
        public Task<Color> GetById(short id);
    }
}
