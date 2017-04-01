using System.Collections.Generic;
using MediatR;

namespace Company.Domain.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResult>
    {
        public int CustomerId { get; set; }

        public IEnumerable<OrderLineCommandModel> OrderLines { get; set; }
    }
}
