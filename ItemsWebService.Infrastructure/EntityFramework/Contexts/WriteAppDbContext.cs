using ItemsWebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemsWebService.Infrastructure.EntityFramework.Contexts
{
    internal class WriteAppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public WriteAppDbContext(DbContextOptions<WriteAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("items");
            base.OnModelCreating(builder);
        }
    }
}
