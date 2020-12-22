using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Base
{
    public abstract class Entity<T> : IEntity<T>
    {
        /// <inheritdoc/>
        public T Id { get; set; }
    }
}
