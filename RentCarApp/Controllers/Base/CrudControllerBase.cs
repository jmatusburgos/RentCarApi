using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentCarApp.BusinessLogic.Contracts.Base;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.Domain.Models.Base.Contracts;
using RentCarApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarApp.Controllers.Base
{
    /// <summary>
    /// Controller crud Base
    /// </summary>
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class CrudControllerBase<T, TKey> : ApiControllerBase<T, TKey> where T : class, IEntity
    {
        #region Private Members

        private readonly IService<T, TKey> _service;
        private readonly IValidationError _validationErrors;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        /// <summary>
        /// Default controller
        /// </summary>
        /// <param name="repository"></param>
        public CrudControllerBase(IService<T, TKey> service, IValidationError validationErrors) : base(service, validationErrors)
        {
            _service = service;
            _validationErrors = validationErrors;
            

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get() => Ok(_service.GetAll());

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        public virtual async Task<IActionResult> GetAsync(TKey id)
        {
            var record = await _service.Find(id);
            if (record == null)
                return NotFound(_validationErrors.GetErrors());

            return Ok(record);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post(T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Create(entity);
            return Ok(entity);
        }

        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(TKey id, T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Modify(id, entity);

            if (_validationErrors.Any())
                return BadRequest(_validationErrors.GetErrors());

            return Ok(entity);
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TKey id)
        {
            var entity = await _service.Delete(id);

            if (entity == null || _validationErrors.Any())
                return BadRequest(_validationErrors.GetErrors());

            return Ok(entity);
        }

        #endregion



    }
}
