using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EShop.Data.Entities;
using EShop.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName)
                .IsRequired(true)
                .HasMaxLength(200);

            builder.Property(x => x.Dob)
                .IsRequired(true);

            builder.Property(x => x.Avatar)
                .IsRequired(true);

            builder.Property(x => x.Address)
                .IsRequired(true)
                .HasMaxLength(500);

            builder.Property(x => x.Gender)
                .HasDefaultValue(Gender.Male);

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
