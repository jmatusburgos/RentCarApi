using RentCarApp.Domain.Models.Base;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Product
{
    public class Category : Catalog<Guid>, IModifiableEntity, IDeactivatable
    {
        public bool IsEnable { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? ModifiedDate { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string CreatedBy { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string ModifiedBy { get; set; }
    }
}
