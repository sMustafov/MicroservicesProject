namespace OrderApi.Service.Services
{
    using System;
    using MediatR;
    using OrderApi.Service.Command;
    using OrderApi.Service.Models;
    using OrderApi.Service.Query;
    public class CustomerNameUpdateService : ICustomerNameUpdateService
    {
        private readonly IMediator mediator;
        public CustomerNameUpdateService(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async void UpdateCustomerNameInOrders(UpdateCustomerFullNameModel updateCustomerFullNameModel)
        {
            try
            {
                var ordersOfCustomer = await this.mediator.Send(new GetOrderByCustomerGuidQuery
                {
                    CustomerGuid = updateCustomerFullNameModel.Id
                });

                if(ordersOfCustomer.Count != 0)
                {
                    ordersOfCustomer
                        .ForEach(x => x.CustomerFullName = $"{updateCustomerFullNameModel.FirstName} {updateCustomerFullNameModel.LastName}");
                }

                await this.mediator.Send(new UpdateOrderCommand
                {
                    Orders = ordersOfCustomer
                });
            }
            catch (Exception)
            {
                throw new Exception("Could not update customer name!");
            }
        }
    }
}
