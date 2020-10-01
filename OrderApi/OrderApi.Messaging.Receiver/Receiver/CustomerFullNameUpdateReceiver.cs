namespace OrderApi.Messaging.Receiver.Receiver
{
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using OrderApi.Messaging.Receiver.Options;
    using OrderApi.Service.Models;
    using OrderApi.Service.Services;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    public class CustomerFullNameUpdateReceiver : BackgroundService
    {
        private IModel channel;
        private IConnection connection;
        
        private readonly string hostname;
        private readonly string queueName;
        private readonly string username;
        private readonly string password;

        private readonly ICustomerNameUpdateService customerNameUpdateService;
        public CustomerFullNameUpdateReceiver(ICustomerNameUpdateService customerNameUpdateService, IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            this.hostname = rabbitMqOptions.Value.Hostname;
            this.queueName = rabbitMqOptions.Value.QueueName;
            this.username = rabbitMqOptions.Value.UserName;
            this.password = rabbitMqOptions.Value.Password;
            this.customerNameUpdateService = customerNameUpdateService;
            InitializeRabbitMqListener();
        }
        private void InitializeRabbitMqListener()
        {
            var factory = new ConnectionFactory
            {
                HostName = this.hostname,
                UserName = this.username,
                Password = this.password
            };

            using (var connection = factory.CreateConnection())
            this.connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            using (this.channel = connection.CreateModel())
            {
                this.channel.QueueDeclare(
                   queue: this.queueName,
                   durable: false,
                   exclusive: false,
                   autoDelete: false,
                   arguments: null);
            }           
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(this.channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var updateCustomerFullNameModel = JsonConvert.DeserializeObject<UpdateCustomerFullNameModel>(content);

                HandleMessage(updateCustomerFullNameModel);

                this.channel.BasicAck(ea.DeliveryTag, false);
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            this.channel.BasicConsume(this.queueName, false, consumer);

            return Task.CompletedTask;
        }
        private void HandleMessage(UpdateCustomerFullNameModel updateCustomerFullNameModel)
        {
            this.customerNameUpdateService.UpdateCustomerNameInOrders(updateCustomerFullNameModel);
        }
        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e)
        {
        }
        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
        }
        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
        }
        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
        }
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }
        public override void Dispose()
        {
            this.channel.Close();
            this.connection.Close();
            base.Dispose();
        }
    }
}
