namespace CustomerApi.Messaging.Send.Sender
{
    using CustomerApi.Domain.Entities;
    using CustomerApi.Messaging.Send.Options;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using System.Text;
    public class CustomerUpdateSender : ICustomerUpdateSender
    {
        private readonly string hostname;
        private readonly string queueName;
        private readonly string username;
        private readonly string password;
        public CustomerUpdateSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            this.hostname = rabbitMqOptions.Value.Hostname;
            this.queueName = rabbitMqOptions.Value.QueueName;
            this.username = rabbitMqOptions.Value.UserName;
            this.password = rabbitMqOptions.Value.Password;
        }
        public void SendCustomer(Customer customer)
        {
            var factory = new ConnectionFactory() 
            { 
                HostName = this.hostname, 
                UserName = this.username, 
                Password = this.password 
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: this.queueName, 
                    durable: false, 
                    exclusive: false, 
                    autoDelete: false, 
                    arguments: null);

                var json = JsonConvert.SerializeObject(customer);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "", routingKey: this.queueName, basicProperties: null, body: body);
            }
        }
    }
}
