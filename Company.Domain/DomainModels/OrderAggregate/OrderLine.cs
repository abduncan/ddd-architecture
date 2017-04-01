namespace Company.Domain.DomainModels.OrderAggregate
{
    public class OrderLine
    {
        // This is a private set because
        // it cannot be changed.
        public int Id { get; private set; }

        // Quantity and ProductId have a public
        // setter because they can both be
        // updated. Maybe the product id changes
        // if the user wants to change from red
        // shoes to black. The same applies to
        // Quantity. Maybe the user wants two
        // pair instead of one.
        public int Quantity { get; set; }

        public int ProductId { get; set; }

        // We use a private set because an order
        // line cannot be changed to a different
        // order.
        public int OrderId { get; private set; }

        // We use a private set because an order
        // line cannot be changed to a different
        // order.
        public virtual Order Order { get; private set; }
        
        // Private constructor to allow entity
        // framework to instantiate the the class.
        private OrderLine() { }

        // We require the Quantity and ProductId
        // to be set in the constructor.  This prevents
        // the OrderLine object from being instantiated
        // in an invalid state.  Since these two
        // properties are required, we should not let
        // the object be created without them.
        public OrderLine(int quantity, int productId, Order order)
        {
            Quantity = quantity;
            ProductId = productId;
            // The order line cannot be changed
            // to a different order once
            // it has been added to one.
            Order = order;
        }
    }
}
