using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Books.API
{
    public class QueueManager
    {
        public static void Enqueue(KeyValuePair<string, Book> data)
        {
            var factory = new ConnectionFactory() { HostName = "host.docker.internal", Port=5672 };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "books",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize<KeyValuePair<string, Book>>(data));

                channel.BasicPublish(exchange: "",
                                     routingKey: "books",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
