namespace CustomerApi.Service.Command
{
    using CustomerApi.Domain.Entities;
    using MediatR;
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }
}