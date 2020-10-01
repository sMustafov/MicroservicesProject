namespace OrderApi.Service.Command
{
    using MediatR;
    using OrderApi.Data.Repository;
    using OrderApi.Domain;
    using System.Threading;
    using System.Threading.Tasks;
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IRepository<Order> repository;
        public UpdateOrderCommandHandler(IRepository<Order> repository)
        {
            this.repository = repository;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            await this.repository.UpdateRangeAsync(request.Orders);

            return Unit.Value;
        }
    }
}
