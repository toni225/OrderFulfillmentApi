using OrderFulfillment.Shared;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrderApi.Services
{
    public class OrderPublisher : IOrderPublisher
    {
        private readonly IConfiguration _config;

        public OrderPublisher(IConfiguration config)
        {
            _config = config;
        }

        public async Task Publish(OrderMessage message)
        {
            var factory = new ConnectionFactory
            {
                HostName = _config["RabbitMq:Host"]!,
                UserName = _config["RabbitMq:Username"]!,
                Password = _config["Password"]!,
            };

            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: "orders", durable: true, exclusive: false, autoDelete: false
            );

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            var properties = new BasicProperties
            {
                Persistent = true
            };

            await channel.BasicPublishAsync(
                exchange: "", routingKey: "orders", mandatory: false, basicProperties: properties, body: body
            );
        }
    }
}
