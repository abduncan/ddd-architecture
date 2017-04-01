using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.DomainModels.ProductAggregate
{
    public class Product
    {
        public int Id { get; private set; } = 0;

        public string Name { get; set; }
        public decimal Price { get; set; }

        private Product() { }

        public Product(string name, decimal price)
        {
            // Perform validation before allowing
            // the object to be instantiated to
            // prevent it from being instantiated
            // in an invalid state.
            Validate(name, price);

            Name = name;
            Price = price;
        }

        private void Validate(string name, decimal price)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "name cannot be null or whitespace");
            if(price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), price, "price must be greater than 0");
        }
    }
}
