using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Configurations
{
    /// <summary>
    /// class for Auth Settings service
    /// </summary>
    public class AuthenticationSettings
    {
        /// <summary>
        /// secret key
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// expiration days
        /// </summary>
        public int ExpirationDays { get; set; }
    }
}
