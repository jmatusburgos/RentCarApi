using AutoMapper;
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
    public abstract class ControllerBaseCatalog<TCatalog, TKey> : CrudControllerBase<TCatalog, TKey>
        where TCatalog : class, ICatalog<TKey>
    {
        private readonly IService<TCatalog, TKey> _service;
        public ControllerBaseCatalog(IService<TCatalog, TKey> service, IValidationError validationErrors) : base(service, validationErrors)
        {
            _service = service;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public override IActionResult Get() => Ok(_service.GetAll().Select(x => new CatalogDto<TKey>
        {
            Id = x.Id,
            Name = x.Name
        }));

    }
}
