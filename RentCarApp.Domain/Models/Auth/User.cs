using Microsoft.AspNetCore.Identity;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Auth
{
    public class User : IdentityUser<Guid>, IEntity
    {
        /// <summary>
        /// Name of User
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Surname of User
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Thumbnail of User
        /// </summary>
        public string Thumbnail { get; set; }
    }
}
