using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Base.Contracts
{
    /// <summary>
    /// Base for catalog Domain
    /// </summary>
    public interface ICatalog<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Property name for catalog domains
        /// </summary>
        string Name { get; set; }
    }
}
