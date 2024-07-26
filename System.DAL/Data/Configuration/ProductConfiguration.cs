using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.DAL.Models;

namespace System.DAL.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.ImageUrl).HasMaxLength(250);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

            builder.HasMany(p => p.Additions)
                   .WithOne(a => a.Product)
                   .HasForeignKey(a => a.ProductId);
        }
    }
}
