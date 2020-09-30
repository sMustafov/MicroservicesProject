namespace OrderApi.Service.Command
{
    using MediatR;
    using OrderApi.Domain;
    using System.Collections.Generic;
    public class UpdateOrderCommand : IRequest
    {
        public List<Order> Orders { get; set; }
    }
}
