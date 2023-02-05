using ItemsWebService.Infrastructure.EntityFramework.Configurations;
using ItemsWebService.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemsWebService.Infrastructure.EntityFramework.Contexts
{
    public class ReadAppDbContext : DbContext
    {
        public DbSet<ItemReadModel> Items { get; set; }
        public DbSet<ColorReadModel> Colors { get; set; }

        public ReadAppDbContext(DbContextOptions<ReadAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("items");
            builder.ApplyConfiguration<ItemReadModel>(new ReadConfiguration());
            builder.ApplyConfiguration<ColorReadModel>(new ReadConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
