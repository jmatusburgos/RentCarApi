using RentCarApp.BusinessLogic.Contracts;
using RentCarApp.BusinessLogic.Contracts.Base;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.Controllers.Base;
using RentCarApp.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarApp.Controllers
{
    public class OrderController : CrudControllerBase<Order, Guid>
    {
        public OrderController(IOrderService service, IValidationError validationErrors) : base(service, validationErrors)
        {
        }
    }
}
