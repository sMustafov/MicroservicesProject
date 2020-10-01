namespace OrderApi.Service.Query
{
    using System;
    using MediatR;
    using OrderApi.Domain;
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
