namespace CustomerApi.Service.Command
{
    using CustomerApi.Domain.Entities;
    using MediatR;
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }
}
