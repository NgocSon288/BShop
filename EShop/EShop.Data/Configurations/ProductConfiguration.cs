using EShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true);

            builder.Property(x => x.Alias)
                .IsRequired(true);

            builder.Property(x => x.Price)
                .IsRequired(true);

            builder.Property(x => x.Promotion)
                .IsRequired(false);

            builder.Property(x => x.Description)
                .IsRequired(true);

            builder.Property(x => x.Content)
                .IsRequired(true);

            builder.Property(x => x.IsFreeship)
                .HasDefaultValue(false);

            builder.Property(x => x.IsInstallment)
                .HasDefaultValue(false);

            builder.Property(x => x.ViewCount)
                .HasDefaultValue(0);

            builder.Property(x => x.Rating)
                .HasDefaultValue(0);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.CreatedBy)
                .HasDefaultValue("");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.UpdateBy)
                .HasDefaultValue("");

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId);
        }
    }
}
