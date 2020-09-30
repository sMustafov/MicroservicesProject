namespace OrderApi.Service.Command
{
    using MediatR;
    using OrderApi.Data.Repository;
    using OrderApi.Domain;
    using System.Threading;
    using System.Threading.Tasks;
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, Order>
    {
        private readonly IRepository<Order> repository;
        public PayOrderCommandHandler(IRepository<Order> repository)
        {
            this.repository = repository;
        }
        public async Task<Order> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.UpdateAsync(request.Order);
        }
    }
}
