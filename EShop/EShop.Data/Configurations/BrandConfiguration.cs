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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    { 
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .IsRequired(true)
                .HasMaxLength(500);

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Brands)
                .HasForeignKey(b => b.CategoryId);

        }
    }
}
