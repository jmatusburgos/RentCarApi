using RentCarApp.BusinessLogic.Contracts.Base;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.DataAccess.Contracts;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.BusinessLogic.Services
{
    public class GenericService<TEntity, TKey> : ServiceBase<TEntity, TKey>, IGenericService<TEntity, TKey>
       where TEntity : class, IEntity<TKey>
    {
        public GenericService(IUnitOfWork uow, IGenericRepository<TEntity> repository, IValidationError validationError) : base(uow, repository, validationError)
        {
        }
    }
}
