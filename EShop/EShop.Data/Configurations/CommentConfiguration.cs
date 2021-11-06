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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Like)
                .HasDefaultValue(0);

            builder.Property(x => x.Dislike)
                .HasDefaultValue(0);

            builder.Property(x => x.StarNumber)
                .IsRequired(true);

            builder.Property(x => x.Reason)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .IsRequired(true)
                .HasMaxLength(500);

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

            builder.HasOne(c => c.AppUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.AppUserId);

            builder.HasOne(c => c.Product)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.ProductId);
        }
    }
}
