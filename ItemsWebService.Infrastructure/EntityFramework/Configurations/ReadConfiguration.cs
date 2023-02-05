using ItemsWebService.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItemsWebService.Infrastructure.EntityFramework.Configurations
{
    internal class ReadConfiguration : IEntityTypeConfiguration<ItemReadModel>, IEntityTypeConfiguration<ColorReadModel>
    {
        public void Configure(EntityTypeBuilder<ItemReadModel> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(k => k.Id);

            builder.HasOne(p => p.Color)
                .WithMany(p => p.Items)
                .HasForeignKey(k => k.ColorId);
        }

        public void Configure(EntityTypeBuilder<ColorReadModel> builder)
        {
            builder.ToTable("Colors");
            builder.HasKey(k => k.Id);
        }
    }
}
