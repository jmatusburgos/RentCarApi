using Microsoft.EntityFrameworkCore;
using RentCarApp.DataAccess.Contracts;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentCarApp.DataAccess.Repositories.Base
{
    /// <summary>
    /// Abstract class base repository
    /// </summary>
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {

        #region Private Members

        private readonly TContext context;

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public DbSet<TEntity> GetDbSet()
        => context.Set<TEntity>();

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public IQueryable<TEntity> GetAll()
        => GetDbSet();

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        => await GetDbSet().AnyAsync(predicate);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        => await GetDbSet().FirstOrDefaultAsync(predicate);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        => GetDbSet().Where(predicate);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public async Task<TEntity> FindByKey(params object[] keyValues)
        => await GetDbSet().FindAsync(keyValues);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public virtual TEntity Add(TEntity entity)
        {
            if (IsModifiableEntity(entity))
                SetDefaultModifiable(entity, EntityState.Added);

            GetDbSet().Add(entity);
            return entity;
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public virtual async Task AddRange(IEnumerable<TEntity> entites)
        => await GetDbSet().AddRangeAsync(entites);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public virtual void Edit(TEntity entity)
        {
            if (IsModifiableEntity(entity))
                SetDefaultModifiable(entity, EntityState.Modified);

            context.Entry(entity).State = EntityState.Modified;
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public void SetValues(TEntity entity, TEntity newValuesEntity)
        => context.Entry(entity).CurrentValues.SetValues(newValuesEntity);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public void SetValues(TEntity entity, object newValuesEntity)
        => context.Entry(entity).CurrentValues.SetValues(newValuesEntity);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public virtual void Patch(TEntity entity, IEnumerable<string> properties)
        {
            GetDbSet().Attach(entity);
            var entry = context.Entry(entity);
            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }

            if (IsModifiableEntity(entity))
                SetDefaultModifiable(entity, EntityState.Modified);
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public virtual void Delete(TEntity entity)
        {
            if (IsDeletableEntity(entity))
                SoftDelete(entity);
            else
                HardDelete(entity);
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public async Task<TEntity> Delete(params object[] keyValues)
        {
            var entity = await FindByKey(keyValues);
            if (entity == null) return null;
            Delete(entity);
            return entity;
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public void DeleteBy(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = FindBy(predicate);
            DeleteRange(entities.AsEnumerable());
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public void DeleteRange(IEnumerable<TEntity> entities)
        => GetDbSet().RemoveRange(entities);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public virtual async Task Save()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

            }

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Do a SoftDelete , no delete phisicaly the record
        /// </summary>
        /// <param name="entity"></param>
        private void SoftDelete(TEntity entity)
        {
            var deletable = entity as ISoftDeletable;

            if (deletable == null)
                return;

            deletable.IsDeleted = true;

            if (IsModifiableEntity(entity))
                (entity as IModifiableEntity).ModifiedDate = DateTime.Now;

            Edit(entity);
        }

        /// <summary>
        /// Get if the entity implement IsDeletable interface
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static bool IsDeletableEntity(TEntity entity)
         => entity is ISoftDeletable;

        /// <summary>
        /// Get if the entity implement IModifiableEntity interface
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static bool IsModifiableEntity(TEntity entity)
         => entity is IModifiableEntity;

        /// <summary>
        /// Do a Hard Delete , remove the record of the database
        /// </summary>
        /// <param name="entity"></param>
        private void HardDelete(TEntity entity)
        {
            GetDbSet().Attach(entity);
            GetDbSet().Remove(entity);
        }

        /// <summary>
        /// Set Default values for Modifiable Entity
        /// </summary>
        /// <param name="entity"></param>
        private void SetDefaultModifiable(TEntity entity, EntityState state)
        {
            var modifiableEntity = entity as IModifiableEntity;

            if (state == EntityState.Added)
                modifiableEntity.CreatedDate = DateTime.UtcNow;

            if (state == EntityState.Modified)
                modifiableEntity.ModifiedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Begins tracking the given entity in Context and set the <see cref="EntityEntry.State"/>
        /// with <paramref name="state"/> value
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to Attach</param>
        /// <param name="state"><see cref="EntityState"/> to set</param>
        protected void Attach(TEntity entity, EntityState state)
        {


        }

        #endregion
    }
}
