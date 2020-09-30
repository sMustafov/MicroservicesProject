namespace OrderApi.Service.Command
{
    using MediatR;
    using OrderApi.Data.Repository;
    using OrderApi.Domain;
    using System.Threading;
    using System.Threading.Tasks;
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IRepository<Order> repository;

        public CreateOrderCommandHandler(IRepository<Order> repository)
        {
            this.repository = repository;
        }
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.AddAsync(request.Order); 
        }
    }
}
