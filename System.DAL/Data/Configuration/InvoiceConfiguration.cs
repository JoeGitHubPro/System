using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.DAL.Models;

namespace System.DAL.Data.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.InvoiceId);
            builder.Property(i => i.InvoiceDate).IsRequired();
            builder.Property(i => i.TotalPrice).HasColumnType("decimal(18,2)");

            builder.HasOne(i => i.Order)
                   .WithOne()
                   .HasForeignKey<Invoice>(i => i.OrderId);
        }
    }
}
