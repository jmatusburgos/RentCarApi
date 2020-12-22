using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.DataAccess.Extensions;
using RentCarApp.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Maps.Car
{
    public class CategoryConfiguration : EntityMappingConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category), "Product").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.SeedCategories();
        }
    }
}
