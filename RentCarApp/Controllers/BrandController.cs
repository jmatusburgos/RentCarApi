using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentCarApp.BusinessLogic.Contracts.Base;
using RentCarApp.BusinessLogic.Services;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.Domain.Models.Product;
using RentCarApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarApp.Controllers
{
    public class BrandController : Base.ControllerBaseCatalog<Brand, Guid>
    {
        
        public BrandController(IGenericService<Brand, Guid> service, IValidationError validationErrors) : base(service, validationErrors)
        {

        }
        
    }
}
