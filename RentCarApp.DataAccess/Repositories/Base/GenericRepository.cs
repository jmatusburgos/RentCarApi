using RentCarApp.DataAccess.Context;
using RentCarApp.DataAccess.Contracts;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Repositories.Base
{
    public class GenericRepository<TEntity> : BaseRepository<TEntity, MainDbContext>, IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        public GenericRepository(MainDbContext context) : base(context)
        {
        }
    }
}
