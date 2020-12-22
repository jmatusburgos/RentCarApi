using RentCarApp.Domain.Models.Base;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Product
{
    public class Brand : Catalog<Guid>, IDeactivatable, IModifiableEntity
    {
        /// <inheritdoc/>
        public bool IsEnable { get; set; }
        /// <inheritdoc/>
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime CreatedDate { get; set; }
        /// <inheritdoc/>
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? ModifiedDate { get; set; }
        /// <inheritdoc/>
        [System.Text.Json.Serialization.JsonIgnore]
        public string CreatedBy { get; set; }
        /// <inheritdoc/>
        [System.Text.Json.Serialization.JsonIgnore]
        public string ModifiedBy { get; set; }
    }
}
