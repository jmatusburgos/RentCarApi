using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.DataAccess.Extensions;
using RentCarApp.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Maps.Car
{
    public class ModelConfiguration : EntityMappingConfiguration<Model>
    {
        public override void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable(nameof(Model), "Product").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.NoAction);
            

            builder.SeedModels();
        }
    }
}
