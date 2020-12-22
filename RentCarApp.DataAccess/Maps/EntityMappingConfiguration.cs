using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.DataAccess.Maps.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Maps
{
    /// <summary>
    /// Class for entity configuration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityMappingConfiguration<T> : IEntityMappingConfiguration<T> where T : class
    {
        /// <summary>
        /// Method to configure entity
        /// </summary>
        /// <param name="builder"></param>
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}
