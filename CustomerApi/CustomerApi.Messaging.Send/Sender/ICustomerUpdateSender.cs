namespace CustomerApi.Messaging.Send.Sender
{
    using CustomerApi.Domain.Entities;
    public interface ICustomerUpdateSender
    {
        void SendCustomer(Customer customer);
    }
}
