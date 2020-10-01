namespace CustomerApi.Service.Command
{
    using CustomerApi.Data.Repository;
    using CustomerApi.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly IRepository<Customer> repository;
        public CreateCustomerCommandHandler(IRepository<Customer> repository)
        {
            this.repository = repository;
        }
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.AddAsync(request.Customer);
        }
    }
}
