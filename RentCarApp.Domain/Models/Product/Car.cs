using RentCarApp.Domain.Enums;
using RentCarApp.Domain.Models.Base;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Product
{
    /// <summary>
    /// Car Domain
    /// </summary>
    public class Car : CommonEntity<Guid>, IDeactivatable
    {

        /// <summary>
        /// Price of rent
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Year of Car
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// number of seats
        /// </summary>
        public int Seats { get; set; }

        /// <summary>
        /// Number of doors
        /// </summary>
        public int Doors { get; set; }

        /// <summary>
        /// Transmission type of car
        /// </summary>
        public Transmission Transmission { get; set; }

        /// <summary>
        /// Id of Brand
        /// </summary>
        public Guid BrandId { get; set; }

        /// <summary>
        /// Id of Model
        /// </summary>
        public Guid ModelId { get; set; }

        /// <summary>
        /// Id of category
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <inheritdoc/>
        public bool IsEnable { get; set; }

        /// <summary>
        /// Navigation Property of Brand
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Brand Brand { get; set; }
        /// <summary>
        /// Navigation property of Model
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Model Model { get; set; }

        /// <summary>
        /// Navigation property of Category
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
