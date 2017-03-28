namespace Company.Domain.DomainModels.Order
{
    class OrderLine
    {

        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int SalesOrderId { get; }

        // We require the Quantity and ProductId
        // to be set in the constructor.  This prevents
        // the OrderLine object from being instantiated
        // in an invalid state.  Since these two
        // two properties are required, we should not let
        // the object be created without them.
        public OrderLine(int quantity, int productId, int salesOrderId)
        {
            Quantity = quantity;
            ProductId = productId;
            // The sales order line cannot be changed
            // to a different sales order once
            // it has been added to one.
            SalesOrderId = salesOrderId;
        }
    }
}
