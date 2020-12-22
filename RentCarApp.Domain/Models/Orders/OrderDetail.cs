using RentCarApp.Domain.Models.Base;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Order
{
    public class OrderDetail : Entity<Guid>, IModifiableEntity
    {
        /// <summary>
        /// Order Id
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Car Id
        /// </summary>
        public Guid CarId { get; set; }

        /// <summary>
        /// days for rent
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// Price for car on Order
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public decimal Price { get; set; }

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

        /// <summary>
        /// Virtual Property for order entity
        /// </summary>
        
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Order Order { get; set; }

        /// <summary>
        /// Virtual property for Car entity
        /// </summary>
        
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Product.Car Car { get; set; }
    }
}
