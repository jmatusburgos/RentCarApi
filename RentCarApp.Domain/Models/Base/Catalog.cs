using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Base
{
    /// <summary>
    /// Base class for catalog
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Catalog<T> : ICatalog<T>
    {
        /// <inheritdoc/>
        public T Id { get; set; }
        
        /// <inheritdoc/>
        public string Name { get; set; }
        
    }
}
