using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Maps.Orders
{
    /// <summary>
    /// Entity Configuration for OrderDetail
    /// </summary>
    public class OrderDetailConfiguration : EntityMappingConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable(nameof(OrderDetail), "Sales").HasKey(x => x.Id);
            builder.Property(p => p.Price).HasColumnType("decimal(15,2)");

            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Car).WithMany().HasForeignKey(x => x.CarId);
        }
    }
}
