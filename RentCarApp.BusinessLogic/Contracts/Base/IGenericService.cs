using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.BusinessLogic.Contracts.Base
{
    public interface IGenericService<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : class, IEntity
    {
    }
}
