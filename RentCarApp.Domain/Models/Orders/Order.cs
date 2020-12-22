using RentCarApp.Domain.Models.Base;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Order
{
    public class Order : Entity<Guid>, IModifiableEntity, IHaveCode
    {
        /// <inheritdoc/>
        [System.Text.Json.Serialization.JsonIgnore]
        public string Code { get; set; }

        /// <summary>
        /// Total Amount of Order
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public decimal TotalAmount { get; set; }

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

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
