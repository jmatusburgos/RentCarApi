using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Base.Contracts
{
    /// <summary>
    /// Default Entity Interface
    /// </summary>
    public interface IEntity
    {
    }

    /// <summary>
    /// Entity Base Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }
}
