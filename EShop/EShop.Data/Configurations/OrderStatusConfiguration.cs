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
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatuses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .IsRequired(true);

            builder.Property(x => x.Color)
                .IsRequired(true);
        }
    }
}
