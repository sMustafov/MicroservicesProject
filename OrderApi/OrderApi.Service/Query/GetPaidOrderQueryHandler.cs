namespace OrderApi.Service.Query
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using OrderApi.Data.Repository;
    using OrderApi.Domain;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetPaidOrderQueryHandler : IRequestHandler<GetPaidOrderQuery, List<Order>>
    {
        private readonly IRepository<Order> repository;

        public GetPaidOrderQueryHandler(IRepository<Order> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Order>> Handle(GetPaidOrderQuery request, CancellationToken cancellationToken)
        {
            return await this.repository
                    .GetAll()
                    .Where(x => x.OrderState == 2)
                    .ToListAsync(cancellationToken);
        }
    }
}
