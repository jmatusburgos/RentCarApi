using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentCarApp.DataAccess.Contracts
{
    /// <summary>
    /// Repositorio base para implementarse de manera genérica
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region Public Methods

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entity"></param>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Add range of Entity
        /// </summary>
        /// <param name="entites"></param>
        Task AddRange(IEnumerable<TEntity> entites);

        /// <summary>
        ///Get true if exists Any record by expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete Entity by keyValues
        /// </summary>
        /// <param name="keyValues"></param>
        Task<TEntity> Delete(params object[] keyValues);

        /// <summary>
        /// Delete entity By Expression
        /// </summary>
        /// <param name="predicate"></param>
        void DeleteBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Delete a collection of Entity
        /// </summary>
        /// <param name="entities"></param>
        /// <remarks>Autor: David Gonzalez</remarks>
        void DeleteRange(IEnumerable<TEntity> entities);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        void Edit(TEntity entity);

        /// <summary>
        /// Get IQueriable by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Find By Key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TEntity> FindByKey(params object[] keyValues);

        /// <summary>
        /// Get First record by Expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// GetAll IQueriable
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// GetDbSet
        /// </summary>
        /// <returns></returns>
        DbSet<TEntity> GetDbSet();

        /// <summary>
        /// Do a Patch of Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="properties"></param>
        void Patch(TEntity entity, IEnumerable<string> properties);

        /// <summary>
        /// Save repository Context
        /// </summary>
        Task Save();

        /// <summary>
        /// Actualiza valores a una entidad existente
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="newValuesEntity"></param>
        void SetValues(TEntity entity, TEntity newValuesEntity);

        /// <summary>
        /// Actualiza valores a una entidad existente segun valores de un Diccionario de propiedades
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="newValuesEntity"></param>
        void SetValues(TEntity entity, object newValuesEntity);

        #endregion Public Methods
    }
}
