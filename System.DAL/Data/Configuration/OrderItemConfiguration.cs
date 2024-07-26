using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.DAL.Models;

namespace System.DAL.Data.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.OrderItemId);
            builder.Property(oi => oi.Quantity).IsRequired();
            builder.Property(oi => oi.DesignImageUrl).HasMaxLength(250);
            builder.Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Ignore(oi => oi.TotalPrice); // TotalPrice is calculated property

            builder.HasOne(oi => oi.Product)
                   .WithMany()
                   .HasForeignKey(oi => oi.ProductId);
        }
    }
}
