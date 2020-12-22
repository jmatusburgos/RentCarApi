using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Maps.Orders
{
    public class OrderConfiguration : EntityMappingConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order), "Sales").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.TotalAmount).HasColumnType("decimal(15,2)");
        }
    }
}
