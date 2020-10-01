namespace CustomerApi.Service.Query
{
    using System;
    using CustomerApi.Domain.Entities;
    using MediatR;
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }
}
