namespace OrderApi.Service.Query
{
    using MediatR;
    using OrderApi.Domain;
    using System.Collections.Generic;
    public class GetPaidOrderQuery : IRequest<List<Order>>
    {
    }
}
