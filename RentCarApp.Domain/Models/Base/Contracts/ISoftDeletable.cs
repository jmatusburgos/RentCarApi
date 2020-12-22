using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Base.Contracts
{
    /// <summary>
    /// Interface to Entity that need a softDelete
    /// </summary>
    public interface ISoftDeletable
    {
        /// <summary>
        /// Indicate if the record is soft deleted
        /// </summary>
        bool IsDeleted { get; set; }

    }
}
