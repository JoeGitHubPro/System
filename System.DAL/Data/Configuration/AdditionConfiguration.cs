using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.DAL.Models;

namespace System.DAL.Data.Configuration
{
    public class AdditionConfiguration : IEntityTypeConfiguration<Addition>
    {
        public void Configure(EntityTypeBuilder<Addition> builder)
        {
            builder.HasKey(a => a.AdditionId);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Price).HasColumnType("decimal(18,2)");
        }
    }
}
