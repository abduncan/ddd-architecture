using System;
using System.Linq;
using Company.Domain.DomainModels.OrderAggregate;
using Company.Domain.Infrastructure;
using MediatR;

namespace Company.Domain.Commands.CreateOrder
{
    // Specific handler of the 
    // CreateOrderCommand. 
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResult>
    {
        private readonly ICreateOrderCommandRepository _repository;
        private readonly IUnitOfWork _uow;

        public CreateOrderCommandHandler(ICreateOrderCommandRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public CreateOrderCommandResult Handle(CreateOrderCommand message)
        {
            var customer = _repository.GetCustomerById(message.CustomerId);
            var productIds = message.OrderLines.Select(l => l.ProductId);
            var products = _repository.GetProductsById(productIds);

            Order order = new Order(customer);

            foreach (var line in message.OrderLines)
            {
                var product = products.Single(p => p.Id == line.ProductId);
                order.AddLine(line.Quantity, product);
            }

            _repository.SaveOrder(order);
            _uow.SaveChanges();
            
            throw new NotImplementedException();
        }
    }
}
