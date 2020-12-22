using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentCarApp.DataAccess.Contracts
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Commit Changes
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Commit Changes Async
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Rollback changes
        /// </summary>
        /// <returns></returns>
        void RollBack();

        /// <summary>
        /// Begin New Transaction
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTransaction();


        IExecutionStrategy CreateStrategy();

        /// <summary>
        /// Commit Current Transaction
        /// </summary>
        void CommitTransaction();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
