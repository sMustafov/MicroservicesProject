namespace OrderApi.Service.Query
{
    using MediatR;
    using OrderApi.Domain;
    using System;
    using System.Collections.Generic;
    public class GetOrderByCustomerGuidQuery : IRequest<List<Order>>
    {
        public Guid CustomerGuid { get; set; }
    }
}
