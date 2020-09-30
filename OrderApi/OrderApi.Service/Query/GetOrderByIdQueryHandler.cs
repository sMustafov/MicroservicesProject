namespace OrderApi.Service.Query
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using OrderApi.Data.Repository;
    using OrderApi.Domain;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IRepository<Order> repository;
        public GetOrderByIdQueryHandler(IRepository<Order> repository)
        {
            this.repository = repository;
        }
        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await this.repository
                    .GetAll()
                    .FirstOrDefaultAsync(
                        x => x.Id == request.Id, 
                        cancellationToken);
        }
    }
}
