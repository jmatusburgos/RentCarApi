using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.DataAccess.Extensions;
using RentCarApp.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Maps.Car
{
    public class BrandConfiguration : EntityMappingConfiguration<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable(nameof(Brand), "Product").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.SeedBrands();

        }
    }
}
