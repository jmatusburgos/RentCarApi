using Microsoft.EntityFrameworkCore;
using RentCarApp.BusinessLogic.Contracts.Base;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.DataAccess.Contracts;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentCarApp.BusinessLogic.Services
{
    /// <summary>
    /// Abstract class for service
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ServiceBase<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, IEntity
    {
        #region Private Members

        private readonly IBaseRepository<TEntity> _repository;
        private readonly IValidationError _validationErrors;
        private readonly IUnitOfWork _uow;

        #endregion

        #region Public Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="repository"></param>
        public ServiceBase(IUnitOfWork uow, IBaseRepository<TEntity> repository, IValidationError validationErrors)
        {
            _uow = uow;
            _repository = repository;
            _validationErrors = validationErrors;
        }


        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> GetAll()
        => _repository.GetAll();

        /// <inheritdoc/>
        public virtual async Task<TEntity> Create(TEntity entity)
        {
            var record = _repository.Add(entity);

            await _uow.CommitAsync();

            return record;
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> Delete(TKey id)
        {
            var entity = await _repository.FindByKey(id);
            if (entity == null)
            {
                _validationErrors.Add("NotFoundEntityToDelete", "Entity to delete not Found");
                return null;
            }

            _repository.Delete(entity);
            await _uow.CommitAsync();

            return entity;
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> Find(params object[] keyValues)
        {
            var record = await _repository.FindByKey(keyValues);
            if (record == null)
            {
                _validationErrors.Add("EntityNotFound", "Tenant Entity no found");
                return null;
            }

            return record;
        }

        /// <inheritdoc/>
        public virtual async Task Modify(TKey id, TEntity entity)
        {
            if (!await ValidateEntityOnUpdate(id, entity))
                return;

            _repository.Edit(entity);
            await _uow.CommitAsync();
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> expression)
        => _repository.FindBy(expression);

        /// <summary>
        /// Validate entity on Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> ValidateEntityOnUpdateAsync(TKey id, TEntity entity)
            => await ValidateEntityOnUpdate(id, entity);

        #endregion

        #region Private Methods

        /// <summary>
        /// Validate if entity IsModifiable type
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static bool IsIModifiable(TEntity entity)
          => entity is IModifiableEntity;



        /// <summary>
        /// Register Error 
        /// </summary>
        /// <param name="errorKey"></param>
        protected void RegisterError(string errorKey)
            => _validationErrors.Add(errorKey, errorKey);

        /// <summary>
        /// Validate Entity on Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private async Task<bool> ValidateEntityOnUpdate(TKey id, TEntity entity)
        {
            var entityId = (entity as IEntity<TKey>).Id;

            if (!Equals(entityId, id))
            {
                RegisterError("Id on record not equal to param");
                return false;
            }

            Expression<Func<TEntity, bool>> expression = x => x.Id.Equals(id);

            var record = await _repository.Any(expression);
            if (!record)
            {
                _validationErrors.Add("NotFoundEntityToModify", "Entity to Update not Found");
                return false;
            }

            return true;
        }

        #endregion
    }
}
