using RentCarApp.Domain.Models.Base;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Product
{
    /// <summary>
    /// Model Domain
    /// </summary>
    public class Model : CommonEntity<Guid>, IDeactivatable, IModifiableEntity
    {
        public Guid BrandId { get; set; }
        public bool IsEnable { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime CreatedDate { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? ModifiedDate { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public string CreatedBy { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public string ModifiedBy { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Brand Brand { get; set; }

    }
}
