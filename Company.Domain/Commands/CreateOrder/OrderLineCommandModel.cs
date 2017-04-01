namespace Company.Domain.Commands.CreateOrder
{
    public class OrderLineCommandModel
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}