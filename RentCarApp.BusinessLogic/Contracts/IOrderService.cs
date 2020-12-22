using RentCarApp.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.BusinessLogic.Contracts
{
    public interface IOrderService : Base.IService<Order,Guid>
    {

    }
}
