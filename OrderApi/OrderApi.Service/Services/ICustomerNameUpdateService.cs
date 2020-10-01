namespace OrderApi.Service.Services
{
    using OrderApi.Service.Models;
    public interface ICustomerNameUpdateService
    {
        void UpdateCustomerNameInOrders(UpdateCustomerFullNameModel updateCustomerFullNameModel);
    }
}
