using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedBrands(this EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
            new Brand { Id = Guid.Parse(Constants.Brands.Toyota), Name = "Toyota", CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true },
            new Brand { Id = Guid.Parse(Constants.Brands.Hyundai), Name = "Hyundai", CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true },
            new Brand { Id = Guid.Parse(Constants.Brands.Kia), Name = "Kia", CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true }
            );
        }

        public static void SeedModels(this EntityTypeBuilder<Model> builder)
        {
            builder.HasData(
            new Model { Id = Guid.NewGuid(), Name = "Accent", Description = "Hyundai Accent", BrandId = Guid.Parse(Constants.Brands.Hyundai), CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable=true },
            new Model { Id = Guid.NewGuid(), Name = "Elantra", Description = "Hyundai Elantra", BrandId = Guid.Parse(Constants.Brands.Hyundai), CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true },

            new Model { Id = Guid.NewGuid(), Name = "Corolla", Description = "Toyota Corolla", BrandId = Guid.Parse(Constants.Brands.Toyota), CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true },
            new Model { Id = Guid.NewGuid(), Name = "Camry", Description = "Toyota Camry", BrandId = Guid.Parse(Constants.Brands.Toyota), CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true },

            new Model { Id = Guid.NewGuid(), Name = "Picanto", Description = "Kia Picanto", BrandId = Guid.Parse(Constants.Brands.Kia), CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true },
            new Model { Id = Guid.NewGuid(), Name = "Rio", Description = "Kia Rio", BrandId = Guid.Parse(Constants.Brands.Kia), CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true }
            );
        }

        public static void SeedCategories(this EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
            new Category { Id = Guid.NewGuid(), Name = "Sedan", CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true },
            new Category { Id = Guid.NewGuid(), Name = "Truck", CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true },
            new Category { Id = Guid.NewGuid(), Name = "hatchback", CreatedBy = "System", CreatedDate = DateTime.Now, IsEnable = true }
            );
        }
    }

    
}
