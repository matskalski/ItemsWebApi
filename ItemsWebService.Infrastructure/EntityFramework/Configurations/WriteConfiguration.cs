using ItemsWebService.Domain.Entities;
using ItemsWebService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ItemsWebService.Infrastructure.EntityFramework.Configurations
{
    internal class WriteConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(k => k.Id);

            var nameConverter = new ValueConverter<ItemName, string>(c => c.Value, c => ItemName.Create(c));
            var codeConverter = new ValueConverter<ItemCode, string>(c => c.Value, c => ItemCode.Create(c));

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, id => ItemId.Create(id));

            builder.Property(typeof(ItemName), "_name")
                .HasConversion(nameConverter)
                .HasColumnName("Name");

            builder.Property(typeof(ItemCode), "_code")
                .HasConversion(codeConverter)
                .HasColumnName("Code");

            builder.Property(typeof(short), "_colorId")
                .HasColumnName("Color");

            builder.Property(typeof(string), "_comment")
                .HasColumnName("Comment");
        }
    }
}
