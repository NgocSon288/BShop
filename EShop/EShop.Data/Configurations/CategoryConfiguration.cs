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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .IsRequired(true);

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
        }
    }
}
