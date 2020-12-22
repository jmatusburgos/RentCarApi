using AutoMapper;
using RentCarApp.BusinessLogic.Contracts.Base;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.Domain.Models.Product;
using RentCarApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarApp.Controllers
{
    public class ModelController : Base.ControllerBaseCatalog<Model, Guid>
    {
        public ModelController(IGenericService<Model, Guid> service, IValidationError validationErrors) : base(service, validationErrors)
        {
        }
    }
}
