namespace OrderApi.Service.Command
{
    using MediatR;
    using OrderApi.Domain;
    public class PayOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
}
