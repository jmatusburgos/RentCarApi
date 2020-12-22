using Microsoft.AspNetCore.Mvc;
using RentCarApp.BusinessLogic.Contracts.Base;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.Domain.Models.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarApp.Controllers.Base
{
    /// <summary>
    /// Controller base
    /// </summary>

    [ApiController]
    public abstract class ApiControllerBase<T, TKey> : ControllerBase
        where T : class, IEntity
    {

        #region Private Members

        private static IService<T, TKey> _service;
        private static IValidationError _validationError;

        #endregion

        #region Public Constructor

        public ApiControllerBase(IService<T, TKey> service, IValidationError validationErrors)
        {
            _service = service;
            _validationError = validationErrors;
        }

        #endregion
    }
}
