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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Address)
                .IsRequired(true)
                .HasMaxLength(500);

            builder.Property(x => x.PhoneNumber)
                .IsRequired(true);
             
            builder.Property(x => x.Message) 
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

            builder.HasOne(o => o.AppUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.AppUserId);

            builder.HasOne(o => o.PaymentMethod)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.PaymentMethodId);

            builder.HasOne(o => o.OrderStatus)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.OrderStatusId);
        }
    }
}
