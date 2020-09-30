namespace OrderApi.Service.Command
{
    using MediatR;
    using OrderApi.Domain;
    public class CreateOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
}
