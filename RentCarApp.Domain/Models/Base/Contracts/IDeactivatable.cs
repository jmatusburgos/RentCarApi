using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Base.Contracts
{
    /// <summary>
    /// Interface to enable Deactivatable property
    /// </summary>
    interface IDeactivatable
    {
        /// <summary>
        /// Property 
        /// </summary>
        public bool IsEnable { get; set; }
    }
}
