using System.Collections.Generic;
using System.Linq;
using Company.Domain.DomainModels.CustomerAggregate;
using Company.Domain.DomainModels.OrderAggregate;
using Company.Domain.DomainModels.ProductAggregate;
using Company.Domain.Infrastructure.Repository;

namespace Company.Domain.Commands.CreateOrder
{
    public interface ICreateOrderCommandRepository
    {
        Customer GetCustomerById(int customerId);
        IEnumerable<Product> GetProductsById(IEnumerable<int> ids);
        void SaveOrder(Order order);
    }

    public class CreateOrderCommandRepository : ICreateOrderCommandRepository
    {
        private readonly AwesomeStoreContext _context;

        public CreateOrderCommandRepository(AwesomeStoreContext context)
        {
            _context = context;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public IEnumerable<Product> GetProductsById(IEnumerable<int> ids)
        {
            return _context.Products.Where(p => ids.Contains(p.Id));
        }

        public void SaveOrder(Order order)
        {
            _context.OrderLines.AddRange(order.OrderLines);
            _context.Orders.Add(order);
        }
    }
}
