using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Base.Contracts
{
    /// <summary>
    /// Interface for entity that has a code
    /// </summary>
    public interface IHaveCode
    {
        /// <summary>
        /// Code identifier of entity
        /// </summary>
        public string Code { get; set; }
    }
}
