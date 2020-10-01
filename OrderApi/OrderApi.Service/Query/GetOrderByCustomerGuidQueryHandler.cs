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
    public class GetOrderByCustomerGuidQueryHandler : IRequestHandler<GetOrderByCustomerGuidQuery, List<Order>>
    {
        private readonly IRepository<Order> repository;
        public GetOrderByCustomerGuidQueryHandler(IRepository<Order> repository)
        {
            this.repository = repository;
        }
        public async Task<List<Order>> Handle(GetOrderByCustomerGuidQuery request, CancellationToken cancellationToken)
        {
            return await this.repository
                    .GetAll()
                    .Where(x => x.CustomerGuid == request.CustomerGuid)
                    .ToListAsync(cancellationToken);
        }
    }
}
