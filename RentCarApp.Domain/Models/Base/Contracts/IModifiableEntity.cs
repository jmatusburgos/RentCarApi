using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Base.Contracts
{
    /// <summary>
    /// Interface for entity with modifiable properties
    /// </summary>
    public interface IModifiableEntity
    {
        /// <summary>
        /// Date of Created
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// Modification Date
        /// </summary>
        DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// User that create the Entity
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// User of the last modification
        /// </summary>
        string ModifiedBy { get; set; }
    }
}
