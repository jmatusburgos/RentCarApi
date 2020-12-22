using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentCarApp.DataAccess.Maps.Contracts;
using RentCarApp.Domain.Models.Auth;
using RentCarApp.Domain.Models.Order;
using RentCarApp.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Context
{
    public class MainDbContext : IdentityDbContext<User, Role, Guid>
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        #region Public DbSet

        /// <summary>
        /// Brand Entity
        /// </summary>
        public DbSet<Brand> Brands { get; set; }
        
        /// <summary>
        /// Cars Entity
        /// </summary>
        public DbSet<Car> Cars { get; set; }

        /// <summary>
        /// Categories Entity
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Models Entity
        /// </summary>
        public DbSet<Model> Models { get; set; }

        /// <summary>
        /// Orders Entity
        /// </summary>
        public DbSet<Order> Order { get; set; }

        /// <summary>
        /// Order Details Entity
        /// </summary>
        public DbSet<OrderDetail> OrderDetails { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(IEntityMappingConfiguration<>).Assembly);
        }

    }
}


