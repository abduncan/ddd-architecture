using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.DomainModels.Order;

namespace Company.Domain.DomainModels.SalesOrder
{
    // Order aggregate root.  Maintains the aggregate
    // boundary and protects the aggregate's rules
    // as a whole.
    class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        // Auto initialize readonly property to
        // an empty list to prevent null checks
        // throughout the code.
        public ICollection<OrderLine> OrderLines { get; } = new List<OrderLine>();

        // We require the CustomerId to set in the 
        // constructor.  This prevents the Order 
        // object from being instantiated in an 
        // invalid state.  Since this property
        // is required, we should not let the object 
        // be created without them.
        public Order(int customerId)
        {
            CustomerId = customerId;
            // Encapsulate the business logic
            // of determining the OrderDate.
            // The logic defines that the order
            // date is the time the order is created.
            OrderDate = DateTime.Now;
        }

        /****************************************************
         * 
         * This method illustrates the aggregate root
         * encapsulating aggregate level valiation.
         * The aggregate root is responsible for maintaining
         * the boundaries of the aggregate.
         * 
        ****************************************************/
        public OrderLine AddLine(int quantity, int productId)
        {
            // Encapsulate the business logic of 
            // an order can only have one line per
            // product.

            ValidateProductDoesntExist(productId);

            // Create the OrderLine, passing in it's invariants
            // to the constructor.
            var newLine = new OrderLine(quantity, productId);
            OrderLines.Add(newLine);
            return newLine;
        }

        private void ValidateProductDoesntExist(int productId)
        {
            var existingLine = OrderLines.SingleOrDefault(l => l.ProductId == productId);
            if (existingLine == null)
                throw new InvalidOperationException("That product already exists on the order");
        }
    }
}
