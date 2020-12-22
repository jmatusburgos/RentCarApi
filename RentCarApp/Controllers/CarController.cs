using AutoMapper;
using RentCarApp.BusinessLogic.Contracts.Base;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.Controllers.Base;
using RentCarApp.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarApp.Controllers
{
    public class CarController : CrudControllerBase<Car, Guid>
    {
        public CarController(IGenericService<Car, Guid> service, IValidationError validationErrors) : base(service, validationErrors)
        {
        }
    }
}
