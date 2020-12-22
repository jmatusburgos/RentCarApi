using RentCarApp.BusinessLogic.Contracts;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.DataAccess.Contracts;
using RentCarApp.Domain.Models.Order;
using RentCarApp.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCarApp.BusinessLogic.Services
{
    public class OrderService : ServiceBase<Order, Guid>, IOrderService
    {
        private readonly IValidationError _validationError;
        private readonly IGenericRepository<Car> _carRepository;
        private readonly IGenericRepository<Order> _repository;
        


        public OrderService(IUnitOfWork uow, IGenericRepository<Order> repository, IGenericRepository<Car> carRepository, IValidationError validationErrors) : base(uow, repository, validationErrors)
        {
            _validationError = validationErrors;
            _carRepository = carRepository;
            _repository = repository;
        }

        public async override Task<Order> Create(Order entity)
        {
            await ValidateOrderCars(entity);
            if (_validationError.Any())
                return null;

            entity.TotalAmount = entity.OrderDetails.Sum(x => x.Price * x.Days);
            entity.Code = $"Order-{_repository.GetDbSet().Count()}"; 

            await base.Create(entity);

            return entity;
        }

        private async Task  ValidateOrderCars(Order order)
        {
            foreach (var item in order.OrderDetails)
            {
                var car = await _carRepository.FindByKey(item.CarId);
                if(car == null)
                {
                    _validationError.Add($"ErrorNoExists", $"Error auto con id {car.Id} no existe");
                    return;
                }

                item.Price = car.Price;

            }
        }
    }
}
