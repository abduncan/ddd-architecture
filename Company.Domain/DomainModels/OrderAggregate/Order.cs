using System;
using System.Collections.Generic;
using System.Linq;

namespace Company.Domain.DomainModels.OrderAggregate
{
    // Order aggregate root.  Maintains the aggregate
    // boundary and protects the aggregate's rules
    // as a whole.
    public class Order
    {
        public int Id { get; private set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        // Auto initialize readonly property to
        // an empty list to prevent null checks
        // throughout the code.
        // We use IEnumerable to encapsulate the
        // adding of a line item to the AddLine
        // method.  This allows us to execute
        // aggregate validation when a line is
        // added.
        public virtual IEnumerable<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

        // Private constructor is to allow
        // entity framework to instantiate
        // the class.
        private Order() { }

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
            // date is the time the order is 
            // created.
            OrderDate = DateTime.Now;
        }

        /****************************************************
         * 
         * This method illustrates the aggregate root
         * encapsulating aggregate level validation.
         * The aggregate root is responsible for maintaining
         * the boundaries of the aggregate. So we prevnt the
         * adding of a line directly to the collection of 
         * lines and force the adding of lines through the
         * AddLine method.
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
            var newLine = new OrderLine(quantity, productId, this);

            var orderLines = OrderLines.ToList();
            orderLines.Add(newLine);
            OrderLines = orderLines;

            return newLine;
        }

        private void ValidateProductDoesntExist(int productId)
        {
            var existingLine = OrderLines.SingleOrDefault(l => l.ProductId == productId);
            if (existingLine != null)
                throw new InvalidOperationException("That product already exists on the order");
        }
    }
}
