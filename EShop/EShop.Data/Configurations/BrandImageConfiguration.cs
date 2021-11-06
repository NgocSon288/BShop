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
    public class BrandImageConfiguration : IEntityTypeConfiguration<BrandImage>
    {
        public void Configure(EntityTypeBuilder<BrandImage> builder)
        {
            builder.ToTable("BrandImages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Path)
                .IsRequired(true);

            builder.Property(x => x.Alt)
                .IsRequired(true);

            builder.HasOne(bi => bi.Brand)
                .WithOne(b => b.BrandImage)
                .HasForeignKey<BrandImage>(bi => bi.BrandId);
        }
    }
}
