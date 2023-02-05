using ItemsWebService.Domain.Entities;
using ItemsWebService.Domain.Repositories;
using ItemsWebService.Domain.ValueObjects;
using ItemsWebService.Infrastructure.EntityFramework.Contexts;
using ItemsWebService.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemsWebService.Infrastructure.Repositories
{
    internal class ColorsRepository : IColorsRepository
    {
        private readonly DbSet<ColorReadModel> _colors;

        public ColorsRepository(ReadAppDbContext readAppDbContext)
        {
            _colors = readAppDbContext.Colors;
        }

        public async Task<Color> GetById(short id)
        {
            var color = await _colors
               .AsNoTracking()
               .FirstOrDefaultAsync(f => f.Id == id);

            return Color.Create(ColorId.Create(color.Id), ColorName.Create(color.Name));
        }
    }
}
