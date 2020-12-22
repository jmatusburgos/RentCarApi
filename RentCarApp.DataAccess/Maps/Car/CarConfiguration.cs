using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Maps.Car
{
    public class CarConfiguration : EntityMappingConfiguration<Domain.Models.Product.Car>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.Product.Car> builder)
        {
            builder.ToTable(nameof(Domain.Models.Product.Car), "Product").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Price).HasColumnType("decimal(15,2)");

            builder.HasOne(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId);
            builder.HasOne(x => x.Model).WithMany().HasForeignKey(x => x.ModelId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
        }
    }
}
