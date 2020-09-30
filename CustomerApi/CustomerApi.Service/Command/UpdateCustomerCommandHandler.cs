namespace CustomerApi.Service.Command
{
    using CustomerApi.Data.Repository;
    using CustomerApi.Domain.Entities;
    using CustomerApi.Messaging.Send.Sender;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly IRepository<Customer> repository;
        private readonly ICustomerUpdateSender customerUpdateSender;
        public UpdateCustomerCommandHandler(IRepository<Customer> repository, ICustomerUpdateSender customerUpdateSender)
        {
            this.repository = repository;
            this.customerUpdateSender = customerUpdateSender;
        }
        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await this.repository.UpdateAsync(request.Customer);

            this.customerUpdateSender.SendCustomer(customer);

            return customer;
        }
    }
}
