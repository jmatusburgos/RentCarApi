using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Auth
{
    /// <summary>
    /// Role Entity
    /// </summary>
    public class Role : IdentityRole<Guid>
    {
    }
}
