using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Contracts
{
    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
    {
    }
}
