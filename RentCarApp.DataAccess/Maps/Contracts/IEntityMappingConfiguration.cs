using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Maps.Contracts
{
    public interface IEntityMappingConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
    }
}
